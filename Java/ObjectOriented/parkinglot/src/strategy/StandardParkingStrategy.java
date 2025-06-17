package ObjectOriented.parkinglot.src.strategy;

import ObjectOriented.parkinglot.src.model.enums.SpotType;
import ObjectOriented.parkinglot.src.model.enums.VehicleType;
import ObjectOriented.parkinglot.src.strategy.interfaces.ParkingStrategy;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Map;

public class StandardParkingStrategy implements ParkingStrategy {
    private static final Map<VehicleType, List<SpotType>> COMPATIBILITY_MAP = Map.of(
      VehicleType.MOTORCYCLE, Arrays.asList(SpotType.MOTORCYCLE),
      VehicleType.CAR, Arrays.asList(SpotType.COMPACT, SpotType.LARGE),
      VehicleType.VAN, Arrays.asList(SpotType.LARGE),
      VehicleType.TRUCK, Arrays.asList(SpotType.LARGE)
    );

    @Override
    public List<SpotType> getCompatibleSpots(VehicleType type) {
        return this.COMPATIBILITY_MAP.getOrDefault(type, Collections.emptyList());
    }
}
