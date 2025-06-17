package ObjectOriented.parkinglot.src.model.entity;

import ObjectOriented.parkinglot.src.model.enums.VehicleType;

import java.util.Objects;

// Make the class not inherited through final. The approach being taken is composition over inheritance for extensibility, maintainability reasons.
public final class Vehicle {
    // private variables only set through constructor. Thus enabling data encapsulation.

    // Using final on the field type so that once the VehicleType type variable is assigned a value (in the constructor), it cannot be changed.
    // This enforces immutability for that field, ensuring its value remains constant throughout the lifetime of the Vehicle object.
    private final VehicleType type;
    private final String licensePlate;

    public Vehicle(VehicleType type, String licensePlate) {
        this.type = type;
        this.licensePlate = licensePlate;
    }

    public VehicleType getType() {
        return this.type;
    }

    public String getLicensePlate() {
        return this.licensePlate;
    }

    // Determines if two objects are logically equivalent (not just the same reference).
    // Compare objects based on their data, not just their memory address.
    @Override
    public boolean equals(Object obj) {
        if(this == obj)
            return true;

        if(obj == null || getClass() != obj.getClass())
            return false;

        Vehicle vehicle = (Vehicle) obj;

        return this.type == vehicle.type &&
                Objects.equals(this.licensePlate, vehicle.licensePlate);
    }

    // Provides a hash value for the object, used in hash-based collections to efficiently locate objects.
    // Use this when plan is to use your class as a key in hash-based collections.
    @Override
    public int hashCode() {
        return Objects.hash(type, licensePlate);
    }

    @Override
    public String toString() {
        return String.format("Vehicle{type=%s, licensePlate=%s}", this.type, this.licensePlate);
    }
}
