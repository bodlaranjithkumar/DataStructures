package ObjectOriented.parkinglot.src.manager;

import ObjectOriented.parkinglot.src.model.entity.ParkingSpot;
import ObjectOriented.parkinglot.src.model.entity.ParkingTicket;
import ObjectOriented.parkinglot.src.model.entity.Payment;
import ObjectOriented.parkinglot.src.model.entity.Vehicle;
import ObjectOriented.parkinglot.src.model.enums.SpotType;
import ObjectOriented.parkinglot.src.model.enums.VehicleType;
import ObjectOriented.parkinglot.src.service.TicketGenerationService;
import ObjectOriented.parkinglot.src.strategy.interfaces.ParkingStrategy;
import ObjectOriented.parkinglot.src.strategy.interfaces.PricingStrategy;

import java.time.Duration;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class ParkingLot {
    private final String parkingLotId;
    private final List<ParkingFloor> floors;
    private final Map<String, ParkingTicket> activeTickets;
    private final ParkingStrategy parkingStrategy;
    private final PricingStrategy pricingStrategy;
    private final TicketGenerationService ticketService;
    private final ReadWriteLock lock = new ReentrantReadWriteLock();

    public ParkingLot(String parkingLotId, ParkingStrategy parkingStrategy,
                      PricingStrategy pricingStrategy, TicketGenerationService ticketService) {
        this.parkingLotId = parkingLotId;
        this.floors = new ArrayList<>();
        this.activeTickets = new ConcurrentHashMap<>();
        this.parkingStrategy = parkingStrategy;
        this.pricingStrategy = pricingStrategy;
        this.ticketService = ticketService;
    }

    public String getParkingLotId() { return parkingLotId; }

    public void addFloor(ParkingFloor floor) {
        lock.writeLock().lock();

        try {
            floors.add(floor);
        } finally {
            lock.writeLock().unlock();
        }
    }

    public List<ParkingSpot> findAvailableSpots(VehicleType vehicleType) {
        List<SpotType> compatibleTypes = parkingStrategy.getCompatibleSpots(vehicleType);
        List<ParkingSpot> availableSpots = new ArrayList<>();

        for(SpotType type: compatibleTypes) {
            for(ParkingFloor floor: floors) {
                List<ParkingSpot> floorSpots = floor.getTop2AvailableSpots(type);
                availableSpots.addAll(floorSpots);

                if(!floorSpots.isEmpty()) {
                    return availableSpots;
                }
            }
        }

        return availableSpots;
    }

    public ParkingSpot findFirstAvailableSpot(VehicleType vehicleType) {
        List<SpotType> compatibleTypes = parkingStrategy.getCompatibleSpots(vehicleType);

        for (SpotType spotType : compatibleTypes) {
            for (ParkingFloor floor : floors) {
                ParkingSpot spot = floor.findAvailableSpot(spotType);
                if (spot != null) {
                    return spot;
                }
            }
        }

        return null;
    }

    public ParkingTicket parkVehicle(Vehicle vehicle) {
        ParkingSpot availableSpot = findFirstAvailableSpot(vehicle.getType());

        if(availableSpot == null) {
            return null; // no available spots
        }

        // Try to reserve the spot
        ParkingFloor floor = getFloorByNumber(availableSpot.getFloor());
        if(floor.reserveSpot(availableSpot, vehicle)) {
            // Generate Ticket
            String ticketId = ticketService.generateTicketId();
            ParkingTicket ticket = new ParkingTicket(ticketId, vehicle, availableSpot);
            activeTickets.put(ticketId, ticket);
            return ticket;
        }

        return null;
    }

    public double calculateParkingFee(String ticketId) {
        ParkingTicket ticket = activeTickets.get(ticketId);
        if(ticket == null) {
            throw new IllegalArgumentException("Invalid ticket ID: " + ticketId);
        }

        Duration parkingDuration = ticket.calculateParkingDuration();
        return pricingStrategy.calculateFee(parkingDuration);
    }

    public boolean processExit(String ticketId, Payment payment) {
        ParkingTicket ticket = activeTickets.get(ticketId);
        if(ticket == null) {
            return  false;
        }

        double requiredAmount = calculateParkingFee(ticketId);
        if(payment.getAmount() < requiredAmount) {
            return false; // insufficient amount
        }

        // process exit
        ticket.markAsPaid(payment);
        ParkingSpot spot = ticket.getAssignedSpot();
        ParkingFloor floor = getFloorByNumber(spot.getFloor());
        floor.releaseSpot(spot);

        // Remove from active tickets
        activeTickets.remove(ticket);

        return true;
    }

    public Map<Integer, Map<SpotType, Integer>> getAvailabilityByFloor() {
        lock.readLock().lock();
        try {
            Map<Integer, Map<SpotType, Integer>> availability = new HashMap<>();
            for (ParkingFloor floor : floors) {
                availability.put(floor.getFloorNumber(), floor.getAvailableSpotCounts());
            }
            return availability;
        } finally {
            lock.readLock().unlock();
        }
    }

    public int getTotalAvailableSpots(SpotType type) {
        lock.readLock().lock();
        try {
            return floors.stream()
                    .mapToInt(floor -> floor.getAvailableSpotCountByType(type))
                    .sum();
        } finally {
            lock.readLock().unlock();
        }
    }

    private ParkingFloor getFloorByNumber(int floorNumber) {
        lock.readLock().lock();

        try {
            return floors.stream()
                    .filter(floor -> floor.getFloorNumber() == floorNumber)
                    .findFirst()
                    .orElse(null);
        } finally {
            lock.readLock().unlock();
        }
    }

    public ParkingTicket getTicket(String ticketId) {
        return activeTickets.get(ticketId);
    }

    public int getActiveTicketCount() {
        return activeTickets.size();
    }
}
