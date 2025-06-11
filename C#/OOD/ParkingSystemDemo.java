// Requirements

// Automated parking - multiple levels
// At entrace, get down and it gives a ticket. Ticket needs to have the assigned spot, vehicle number.
// Determines the size of the car and evaluates the allowed spot type
// 3 spot types - S, M, L
// A Small size car can  fit in S,M,L and a Medium car can fit in M,L spot types

// NOTE: If different vehicle types such as bike, suv, truck are added, we will make the Vehicle class & canFitInSpot method abstract and create subclasses for each vehicle type.

// Enum for Vehicle Size

import java.util.ArrayList;
import java.util.List;

enum VehicleSize {
    SMALL, MEDIUM
}

// Enum for Parking Spot Type
enum SpotType {
    SMALL, MEDIUM, LARGE
}

// Vehicle class
class Vehicle {
    private String vehicleNumber;
    private VehicleSize size;

    public Vehicle(String vehicleNumber, VehicleSize size) {
        this.vehicleNumber = vehicleNumber;
        this.size = size;
    }

    public String getVehicleNumber() {
        return vehicleNumber;
    }

    public VehicleSize getSize() {
        return size;
    }

    // Determine if this vehicle can fit in a spot type
    public boolean canFitInSpot(SpotType spotType) {
        switch (size) {
            case SMALL:
                return spotType == SpotType.SMALL || spotType == SpotType.MEDIUM || spotType == SpotType.LARGE;
            case MEDIUM:
                return spotType == SpotType.MEDIUM || spotType == SpotType.LARGE;
            default:
                return false;
        }
    }
}

// ParkingSpot class
class ParkingSpot {
    private String spotId;
    private SpotType spotType;
    private boolean isOccupied;

    public ParkingSpot(String spotId, SpotType spotType) {
        this.spotId = spotId;
        this.spotType = spotType;
        this.isOccupied = false;
    }

    public String getSpotId() {
        return spotId;
    }

    public SpotType getSpotType() {
        return spotType;
    }

    public boolean isOccupied() {
        return isOccupied;
    }

    public boolean assignSpot() {
        if (!isOccupied) {
            isOccupied = true;
            return true;
        }
        return false;
    }

    public void freeSpot() {
        isOccupied = false;
    }

    public boolean canFitVehicle(Vehicle vehicle) {
        return vehicle.canFitInSpot(spotType);
    }
}

// ParkingLevel class
class ParkingLevel {
    public List<ParkingSpot> spots;
    private int levelNumber;

    public ParkingLevel(int levelNumber, List<ParkingSpot> spots) {
        this.levelNumber = levelNumber;
        this.spots = spots;
    }

    public ParkingSpot findAvailableSpot(Vehicle vehicle) {
        for (ParkingSpot spot : spots) {
            if (!spot.isOccupied() && spot.canFitVehicle(vehicle)) {
                return spot;
            }
        }
        return null; // No available spot found
    }

    public int getLevelNumber() {
        return levelNumber;
    }
}

// Ticket class
class Ticket {
    private String ticketId;
    private String spotId;
    private String vehicleNumber;

    public Ticket(String ticketId, String spotId, String vehicleNumber) {
        this.ticketId = ticketId;
        this.spotId = spotId;
        this.vehicleNumber = vehicleNumber;
    }

    public String getTicketId() {
        return ticketId;
    }

    public String getSpotId() {
        return spotId;
    }

    public String getVehicleNumber() {
        return vehicleNumber;
    }

    @Override
    public String toString() {
        return "Ticket{" +
                "ticketId='" + ticketId + '\'' +
                ", spotId='" + spotId + '\'' +
                ", vehicleNumber='" + vehicleNumber + '\'' +
                '}';
    }
}

// ParkingSystem class
class ParkingSystem {
    private List<ParkingLevel> levels;
    private int nextTicketId = 1;

    public ParkingSystem(List<ParkingLevel> levels) {
        this.levels = levels;
    }

    public Ticket enterParking(Vehicle vehicle) {
        // Find an available spot across all levels
        ParkingSpot spot = null;
        for (ParkingLevel level : levels) {
            spot = level.findAvailableSpot(vehicle);
            if (spot != null) {
                break;
            }
        }

        if (spot == null) {
            throw new IllegalStateException("No available parking spot for this vehicle.");
        }

        // Assign the spot
        if (spot.assignSpot()) {
            // Generate ticket with unique ID
            String ticketId = "T" + nextTicketId++;
            Ticket ticket = new Ticket(ticketId, spot.getSpotId(), vehicle.getVehicleNumber());
            return ticket;
        } else {
            throw new IllegalStateException("Failed to assign parking spot.");
        }
    }

    public void exitParking(Ticket ticket) {
        // Find and free the spot (simplified for this example)
        for (ParkingLevel level : levels) {
            for (ParkingSpot spot : level.spots) {
                if (spot.getSpotId().equals(ticket.getSpotId()) && spot.isOccupied()) {
                    spot.freeSpot();
                    return;
                }
            }
        }
        throw new IllegalStateException("Invalid ticket or spot not found.");
    }
}

// Main class for testing
public class ParkingSystemDemo {
    public static void main(String[] args) {
        // Create parking spots for Level 1
        List<ParkingSpot> level1Spots = new ArrayList<>();
        level1Spots.add(new ParkingSpot("S1", SpotType.SMALL));
        level1Spots.add(new ParkingSpot("M1", SpotType.MEDIUM));
        level1Spots.add(new ParkingSpot("L1", SpotType.LARGE));

        // Create parking levels
        List<ParkingLevel> levels = new ArrayList<>();
        levels.add(new ParkingLevel(1, level1Spots));

        // Create parking system
        ParkingSystem parkingSystem = new ParkingSystem(levels);

        // Test with a Small vehicle
        Vehicle smallCar = new Vehicle("ABC123", VehicleSize.SMALL);
        Ticket ticket1 = parkingSystem.enterParking(smallCar);
        System.out.println("Ticket for small car: " + ticket1);

        // Test with a Medium vehicle
        Vehicle mediumCar = new Vehicle("XYZ789", VehicleSize.MEDIUM);
        Ticket ticket2 = parkingSystem.enterParking(mediumCar);
        System.out.println("Ticket for medium car: " + ticket2);

        // Exit parking for the small car
        parkingSystem.exitParking(ticket1);
        System.out.println("Small car exited parking.");
    }
}