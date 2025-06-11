// Requirements

// Multiple elevators in a building
// Request handling (internal and external)
// Elevator movement (up/down)
// State management
// Basic pickup and destination logic

import java.util.*;

// Enum for elevator direction
enum Direction {
    UP,
    DOWN,
    IDLE
}

// Enum for request type
enum RequestType {
    INTERNAL,
    EXTERNAL
}

// Request class to encapsulate pickup/drop-off requests
class Request {
    private int sourceFloor;
    private int destinationFloor;
    private RequestType type;
    
    public Request(int source, int destination, RequestType type) {
        this.sourceFloor = source;
        this.destinationFloor = destination;
        this.type = type;
    }
    
    public int getSourceFloor() { return sourceFloor; }
    public int getDestinationFloor() { return destinationFloor; }
    public RequestType getType() { return type; }
}

// Elevator class
class Elevator {
    private int currentFloor;
    private Direction direction;
    private int id;
    private Queue<Request> requests;
    private final int minFloor;
    private final int maxFloor;
    
    public Elevator(int id, int minFloor, int maxFloor) {
        this.id = id;
        this.currentFloor = 0;
        this.direction = Direction.IDLE;
        this.requests = new LinkedList<>();
        this.minFloor = minFloor;
        this.maxFloor = maxFloor;
    }
    
    public void addRequest(Request request) {
        requests.add(request);
        if (direction == Direction.IDLE) {
            direction = (request.getSourceFloor() > currentFloor) ? Direction.UP : Direction.DOWN;
        }
    }
    
    public void processRequests() {
        while (!requests.isEmpty()) {
            Request currentRequest = requests.peek();
            
            // Move to source floor first
            if (currentFloor != currentRequest.getSourceFloor()) {
                moveToFloor(currentRequest.getSourceFloor());
            }
            
            System.out.println("Elevator " + id + " picked up at floor " + currentFloor);
            
            // Move to destination
            moveToFloor(currentRequest.getDestinationFloor());
            System.out.println("Elevator " + id + " dropped off at floor " + currentFloor);
            
            requests.poll();
        }
        direction = Direction.IDLE;
    }
    
    private void moveToFloor(int targetFloor) {
        if (targetFloor < minFloor || targetFloor > maxFloor) {
            System.out.println("Invalid floor request");
            return;
        }
        
        direction = (targetFloor > currentFloor) ? Direction.UP : Direction.DOWN;
        while (currentFloor != targetFloor) {
            currentFloor += (direction == Direction.UP) ? 1 : -1;
            System.out.println("Elevator " + id + " at floor " + currentFloor);
        }
    }
    
    public int getCurrentFloor() { return currentFloor; }
    public Direction getDirection() { return direction; }
}

// Elevator Controller to manage multiple elevators
class ElevatorController {
    private List<Elevator> elevators;
    private int numberOfFloors;
    
    public ElevatorController(int numElevators, int minFloor, int maxFloor) {
        this.numberOfFloors = maxFloor - minFloor + 1;
        elevators = new ArrayList<>();
        for (int i = 0; i < numElevators; i++) {
            elevators.add(new Elevator(i, minFloor, maxFloor));
        }
    }
    
    public void requestElevator(int sourceFloor, int destinationFloor) {
        Elevator bestElevator = findBestElevator(sourceFloor);
        Request request = new Request(sourceFloor, destinationFloor, RequestType.EXTERNAL);
        bestElevator.addRequest(request);
        bestElevator.processRequests();
    }
    
    private Elevator findBestElevator(int sourceFloor) {
        Elevator best = elevators.get(0);
        int minDistance = Integer.MAX_VALUE;
        
        for (Elevator elevator : elevators) {
            int distance = Math.abs(elevator.getCurrentFloor() - sourceFloor);
            if (distance < minDistance && elevator.getDirection() == Direction.IDLE) {
                minDistance = distance;
                best = elevator;
            }
        }
        return best;
    }
}

// Main class to test the elevator system
public class ElevatorSystem {
    public static void main(String[] args) {
        // Create a building with 2 elevators, floors -2 to 10
        ElevatorController controller = new ElevatorController(2, -2, 10);
        
        // Test case 1: Request from floor 5 to 8
        System.out.println("Requesting elevator from floor 5 to 8:");
        controller.requestElevator(5, 8);
        
        // Test case 2: Request from floor -1 to 3
        System.out.println("\nRequesting elevator from floor -1 to 3:");
        controller.requestElevator(-1, 3);
    }
}