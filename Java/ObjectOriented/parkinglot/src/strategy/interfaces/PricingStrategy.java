package ObjectOriented.parkinglot.src.strategy.interfaces;

import java.time.Duration;

public interface PricingStrategy {
    double calculateFee(Duration parkingDuration);
}
