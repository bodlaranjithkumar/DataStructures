package ObjectOriented.parkinglot.src.service;

import ObjectOriented.parkinglot.src.model.enums.SpotType;

public class SpotIdGenerationService {
    public String generateSpotId(int floor, SpotType type, int spotNumber) {
        return String.format("F%d-%s-%03d", floor, type.name().substring(0, 1), spotNumber);
    }
}
