package ObjectOriented.parkinglot.src.model.entity;

import ObjectOriented.parkinglot.src.model.enums.SpotStatus;
import ObjectOriented.parkinglot.src.model.enums.SpotType;

public class ParkingSpot {
    private final String spotId;
    private final SpotType type;
    private final int floor;

    // The volatile keyword is used here to ensure that changes to the status field are immediately visible to all threads. This is important if multiple
    // threads can access or modify the status of a ParkingSpot concurrently (e.g., in a multi-threaded parking lot system).
    // In this context, volatile helps prevent threads from caching the value and ensures they always read the latest value of status.
    private volatile SpotStatus status;
    private Vehicle currentVehicle; // null when available

    public ParkingSpot(String spotId, SpotType type, int floor) {
        this.spotId = spotId;
        this.type = type;
        this.floor = floor;
        this.status = SpotStatus.AVAILABLE;
        this.currentVehicle = null;
    }

    // The synchronized keyword on the reserve method ensures that only one thread can execute this method on a given ParkingSpot instance at a time.
    // It is used to provide thread safety for critical sections that modify shared state.
    public synchronized boolean reserve(Vehicle vehicle) {
        if(this.status == SpotStatus.AVAILABLE) {
            this.status = SpotStatus.OCCUPIED;
            this.currentVehicle = vehicle;
            return true;
        }

        return false;
    }

    public synchronized void release() {
        this.status = SpotStatus.AVAILABLE;
        this.currentVehicle = null;
    }

    public synchronized void markOutOfOrder() {
        this.status = SpotStatus.OUT_OF_ORDER;
        this.currentVehicle = null;
    }

    public synchronized void markAvailable() {
        if(this.status == SpotStatus.OUT_OF_ORDER) {
            this.status = SpotStatus.AVAILABLE;
            this.currentVehicle = null;
        }
    }

    public boolean isAvailable() {
        return this.status == SpotStatus.AVAILABLE && this.currentVehicle == null;
    }

    @Override
    public String toString() {
        return String.format("ParkingSpot{spotId='%s', type=%s, floor=%d, status=%s}",
                spotId, type, floor, status);
    }

    // GETTERS
    public String getSpotId() { return this.spotId; }
    public SpotType getType() { return this.type; }
    public int getFloor() { return this.floor; }
    public SpotStatus getStatus() { return this.status; }
    public Vehicle getCurrentVehicle() { return this.currentVehicle; }
}
