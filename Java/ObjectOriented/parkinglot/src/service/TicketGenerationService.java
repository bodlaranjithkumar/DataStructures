package ObjectOriented.parkinglot.src.service;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.concurrent.atomic.AtomicLong;

// Using a service class because of the need to manage a state. Otherwise utility class should suffice.
public class TicketGenerationService {
    // The AtomicLong is used to safely manage a counter (ticketCounter) in a multi-threaded environment.
    // It ensures that increment operations are atomic, preventing race conditions when multiple threads generate ticket IDs concurrently.
    // This guarantees each ticket gets a unique, sequential number.
    // NOTE: This works if service is running on single machine. In a distributed environment, we need to use a separate service such as redis's offering of redlock.
    private final AtomicLong ticketCounter = new AtomicLong(1);

    public String generateTicketId() {
        return "TKT-" + LocalDate.now().format(DateTimeFormatter.BASIC_ISO_DATE)
                + "-" + String.format("%60d", ticketCounter.getAndIncrement());
    }
}
