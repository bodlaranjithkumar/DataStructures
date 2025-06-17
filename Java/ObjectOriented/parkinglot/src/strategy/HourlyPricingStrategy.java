package ObjectOriented.parkinglot.src.strategy;

import ObjectOriented.parkinglot.src.strategy.interfaces.PricingStrategy;

import java.time.Duration;

public class HourlyPricingStrategy implements PricingStrategy {
    private static final double FIRST_HOUR_RATE = 4.0;
    private static final double SECOND_THIRD_HOUR_RATE = 3.5;
    private static final double SUBSEQUENT_HOUR_RATE = 2.5;

    @Override
    public double calculateFee(Duration parkingDuration) {
        long totalMinutes = parkingDuration.toMinutes();
        long hours = (totalMinutes + 59) / 60; // Round up to next hour

        if (hours <= 0)
            return 0.0;

        double totalFee = 0.0;

        // First hour
        if (hours >= 1) {
            totalFee += FIRST_HOUR_RATE;
            hours--;
        }

        // Second and third hours
        if (hours >= 1) {
            long secondThirdHours = Math.min(hours, 2);
            totalFee += secondThirdHours * SECOND_THIRD_HOUR_RATE;
            hours -= secondThirdHours;
        }

        // Subsequent hours
        if (hours > 0) {
            totalFee += hours * SUBSEQUENT_HOUR_RATE;
        }

        return totalFee;
    }
}
