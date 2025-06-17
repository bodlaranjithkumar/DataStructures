package ObjectOriented.parkinglot.src.strategy.interfaces;

import ObjectOriented.parkinglot.src.model.enums.SpotType;
import ObjectOriented.parkinglot.src.model.enums.VehicleType;

import java.util.List;

public interface ParkingStrategy {
    List<SpotType> getCompatibleSpots(VehicleType type);
}
