## Step 1: Object Identification (Nouns from Requirements)

**Core Domain Objects:**
- Vehicle (Car, Van, Truck, Motorcycle)
- ParkingSpot (Compact, Large, Handicapped, Motorcycle)
- ParkingTicket
- ParkingFloor
- ParkingLot

**System/Service Objects:**
- ParkingLotManager
- TicketGenerator
- PricingCalculator

**Value Objects:**
- Payment (amount, method, timestamp)
- SpotType (enum)
- VehicleType (enum)
- PaymentMethod (enum)

## Step 2: Class Design & Relationships
Define the core classes with their attributes, methods, and relationships.

Key Relationships to Establish
1. Association Relationships:

ParkingTicket has-a Vehicle (composition)
ParkingTicket has-a ParkingSpot (association)
ParkingFloor has-many ParkingSpot (composition)
ParkingLot has-many ParkingFloor (composition)

2. Service Dependencies:

ParkingLot uses ParkingStrategy
ParkingLot uses PricingStrategy

## Step 3: Container Classes & System Orchestration
Build the higher-level components that manage collections of entities and coordinate the main operations.

**Key Components to Build:**
1. ParkingFloor - Manages spots on a single floor
2. ParkingLot - Manages multiple floors and main operations
3. ParkingLotManager - Orchestrates the entire system (entry/exit operations)

**Core Operations to Support:**
Park Vehicle: Find available spot, issue ticket
Exit & Pay: Calculate fee, process payment, release spot
Get Available Spots: Query capacity by type/floor
Handle Full Capacity: What happens when no spots available