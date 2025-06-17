package ObjectOriented.parkinglot.src.model.entity;

import ObjectOriented.parkinglot.src.model.enums.PaymentMethod;
import java.time.LocalDateTime;

public final class Payment {
    private final double amount;
    private final PaymentMethod method;
    private final LocalDateTime timestamp;

    public Payment(double amount, PaymentMethod method) {
        this.amount = amount;
        this.method = method;
        this.timestamp = LocalDateTime.now();
    }

    @Override
    public String toString() {
        return String.format("Payment{amount=%.2f, method=%s, timestamp=%s", amount, method, timestamp);
    }

    public double getAmount() { return amount; }
    public PaymentMethod getMethod() { return method; }
    public LocalDateTime getTimestamp() { return timestamp; }
}
