package ObjectOriented.parkinglot.src.model.entity;

import java.time.Duration;
import java.time.LocalDateTime;

public class ParkingTicket {
    private final String ticketId;
    private final Vehicle vehicle;
    private final ParkingSpot assignedSpot;
    private final LocalDateTime entryTime;
    private LocalDateTime exitTime;
    private boolean isPaid;
    private Payment payment;

    public ParkingTicket(String ticketId, Vehicle vehicle, ParkingSpot assignedSpot) {
        this.ticketId = ticketId;
        this.vehicle = vehicle;
        this.assignedSpot = assignedSpot;
        this.entryTime = LocalDateTime.now();
        this.isPaid = false;
    }

    public Duration calculateParkingDuration() {
        LocalDateTime endTime = (exitTime != null) ? exitTime : LocalDateTime.now();
        return Duration.between(entryTime, endTime);
    }

    public void markAsPaid(Payment payment) {
        this.payment = payment;
        this.isPaid = true;
        this.exitTime = LocalDateTime.now();
    }

    @Override
    public String toString() {
        return String.format("ParkingTicket{ticketId='%s', vehicle=%s, spot=%s, entryTime=%s, isPaid=%s}",
                ticketId, vehicle.getLicensePlate(), assignedSpot.getSpotId(), entryTime, isPaid);
    }

    // Getters
    public String getTicketId() { return ticketId; }
    public Vehicle getVehicle() { return vehicle; }
    public ParkingSpot getAssignedSpot() { return assignedSpot; }
    public LocalDateTime getEntryTime() { return entryTime; }
    public LocalDateTime getExitTime() { return exitTime; }
    public boolean isPaid() { return isPaid; }
    public Payment getPayment() { return payment; }
}
