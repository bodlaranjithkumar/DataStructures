package ObjectOriented.parkinglot.src.manager;

import ObjectOriented.parkinglot.src.model.entity.ParkingSpot;
import ObjectOriented.parkinglot.src.model.entity.Vehicle;
import ObjectOriented.parkinglot.src.model.enums.SpotType;

import java.util.*;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentLinkedQueue;
import java.util.concurrent.locks.ReadWriteLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class ParkingFloor {
    private final int floorNumber;
    private final Map<SpotType, List<ParkingSpot>> spotsByType;
    private final Map<SpotType, Queue<ParkingSpot>> availableSpotsByType; // offline list for performance
    private final Map<String, ParkingSpot> spotsById;
    private final ReadWriteLock lock = new ReentrantReadWriteLock();

    public ParkingFloor(int floorNumber) {
        this.floorNumber = floorNumber;
        this.spotsByType = new ConcurrentHashMap<>();
        this.availableSpotsByType = new ConcurrentHashMap<>();
        this.spotsById = new ConcurrentHashMap<>();

        // Initialize collections for each spot type
        for(SpotType type : SpotType.values()) {
            spotsByType.put(type, new ArrayList<>());
            availableSpotsByType.put(type, new ConcurrentLinkedQueue<>());
        }
    }

    public int getFloorNumber() { return floorNumber; }

    public void addSpot(ParkingSpot spot) {
        lock.writeLock().lock();

        try {
            spotsByType.get(spot.getType()).add(spot);
            spotsById.put(spot.getSpotId(), spot);
            if(spot.isAvailable()) {
                availableSpotsByType.get(spot.getType()).offer(spot);
            }
        } finally {
            lock.writeLock().unlock();
        }
    }

    public ParkingSpot findAvailableSpot(SpotType type) {
        Queue<ParkingSpot> availableSpots = availableSpotsByType.get(type);

        // Try to get the available spot from the offline list first
        ParkingSpot spot = availableSpots.poll();
        while(spot != null) {
            // Double-check if the spot is still available (handle race condition)
            if(spot.isAvailable()) {
                return spot;
            }
            spot = availableSpots.poll();
        }

        // Fallback: scan all spots of this type (slow path- rare)
        lock.readLock().lock();
        try {
            for(ParkingSpot s : spotsByType.get(type)) {
                if(s.isAvailable()) {
                    return s;
                }
            }
        } finally {
            lock.readLock().unlock();
        }

        return null;
    }

    public boolean reserveSpot(ParkingSpot spot, Vehicle vehicle) {
        return spot.reserve(vehicle);
    }

    public void releaseSpot(ParkingSpot spot) {
        spot.release();
        // Add back to available spots offline list
        availableSpotsByType.get(spot.getType()).offer(spot);
    }

    public int getAvailableSpotCountByType(SpotType type) {
        lock.readLock().lock();

        try {
            return (int)spotsByType.get(type).stream()
                    .filter(ParkingSpot::isAvailable)
                    .count();
        } finally {
            lock.readLock().unlock();
        }
    }

    public Map<SpotType, Integer> getAvailableSpotCounts() {
        lock.readLock().lock();

        try {
            Map<SpotType, Integer> counts = new HashMap<>();
            for(SpotType type : SpotType.values()) {
                counts.put(type, getAvailableSpotCountByType(type));
            }

            return counts;
        } finally {
            lock.readLock().unlock();
        }
    }

    public List<ParkingSpot> getTop2AvailableSpots(SpotType type) {
        List<ParkingSpot> result = new ArrayList<>();
        Queue<ParkingSpot> availableSpots = availableSpotsByType.get(type);

        // Get up to 2 available spots
        Iterator<ParkingSpot> iterator = availableSpots.iterator();
        while(iterator.hasNext() && result.size() < 2) {
            ParkingSpot spot = iterator.next();
            if(spot.isAvailable()) {
                result.add(spot);
            }
        }

        return result;
    }
}
