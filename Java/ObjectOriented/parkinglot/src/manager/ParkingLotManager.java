package ObjectOriented.parkinglot.src.manager;

import ObjectOriented.parkinglot.src.model.entity.ParkingTicket;
import ObjectOriented.parkinglot.src.model.entity.Payment;
import ObjectOriented.parkinglot.src.model.entity.Vehicle;
import ObjectOriented.parkinglot.src.model.enums.PaymentMethod;
import ObjectOriented.parkinglot.src.model.enums.SpotType;

import java.util.Map;

public class ParkingLotManager {
    private final ParkingLot parkingLot;

    public ParkingLotManager(ParkingLot parkingLot) {
        this.parkingLot = parkingLot;
    }

    public ParkingTicket enterParkingLot(Vehicle vehicle) {
        ParkingTicket ticket = parkingLot.parkVehicle(vehicle);
        if(ticket == null) {
            System.out.println("Sorry, no available spots for vehicle type: " + vehicle.getType());
            return null;
        }

        System.out.println("Vehicle parked successfully. Ticket: " + ticket.getTicketId());
        return ticket;
    }

    public boolean exitParkingLot(String ticketId, PaymentMethod paymentMethod, double amount) {
        try {
            double requiredFee = parkingLot.calculateParkingFee(ticketId);
            System.out.println("Parking fee: $" + String.format("%.2f", requiredFee));

            if (amount < requiredFee) {
                System.out.println("Insufficient payment. Required: $" + String.format("%.2f", requiredFee));
                return false;
            }

            Payment payment = new Payment(amount, paymentMethod);
            boolean success = parkingLot.processExit(ticketId, payment);

            if (success) {
                double change = amount - requiredFee;
                System.out.println("Payment successful. Change: $" + String.format("%.2f", change));
                return true;
            } else {
                System.out.println("Exit processing failed.");
                return false;
            }

        } catch (IllegalArgumentException e) {
            System.out.println("Invalid ticket: " + e.getMessage());
            return false;
        }
    }

    public void displayAvailability() {
        Map<Integer, Map<SpotType, Integer>> availability = parkingLot.getAvailabilityByFloor();

        System.out.println("\n=== PARKING AVAILABILITY ===");
        for (Map.Entry<Integer, Map<SpotType, Integer>> floorEntry : availability.entrySet()) {
            System.out.println("Floor " + floorEntry.getKey() + ":");
            for (Map.Entry<SpotType, Integer> spotEntry : floorEntry.getValue().entrySet()) {
                System.out.println("  " + spotEntry.getKey() + ": " + spotEntry.getValue() + " available");
            }
        }
        System.out.println("Active tickets: " + parkingLot.getActiveTicketCount());
        System.out.println("===========================\n");
    }
}
