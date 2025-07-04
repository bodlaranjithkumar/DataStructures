Let's make an object-oriented design for a multi-entrance and exit parking lot
system.

Problem definition
A parking lot is a designated area for parking vehicles and is a feature found in
almost all popular venues such as shopping malls, sports stadiums, offices, etc.
In a parking lot, there are a fixed number of parking spots available for
different types of vehicles. Each of these spots is charged according to the time
the vehicle has been parked in the parking lot. The parking time is tracked with
a parking ticket issued to the vehicle at the entrance of the parking lot. Once
the vehicle is ready to exit, it can either pay at the automated exit panel or to
the parking agent at the exit using a card or cash payment method.

Expectations from the interviewee
In a typical parking lot system, there are several components each with specific
constraints and requirements. The following section provides an overview of some
major expectations the interviewer will want an interviewee to discuss in more
detail during the interview.

Payment flexibility
One of the most significant attributes of the parking lot system is the payment
structure that it provides to its customers. An interviewer would expect you to
ask questions like these:

1. How are customers able to pay at different exit points (i.e., either at the
automated exit panel or to the parking agent) and by different methods (cash,
credit, coupon)?
2. If there are multiple floors in the parking lot, how will the system keep track of
the customer having already paid on a particular floor rather than at the exit?

Parking spot type
Another topic of discussion that an interviewer would expect you to be aware of is
the different parking spot types — handicapped, compact, large, and motorcycle
— regarding which you can ask the following questions:

1. How will the parking capacity of each lot be considered?
2. What happens when a lot becomes full?
3. How can one keep track of the free parking spots on each floor if there are
multiple floors in the parking lot?
4. How will the division of the parking spots be carried out among the four
different parking spot types in the lot?

Vehicle types
Similar to the parking spot, an interviewer would also expect you to discuss the
different vehicle types — car, truck, van, motorcycle — which can have the following
set of questions:

1. How will capacity be allocated for different vehicle types?
2. If the parking spot of any vehicle type is booked, can a vehicle of another type
park in the designated parking spot?

Pricing
We touched upon the payment structure offered by the parking lot system. Now,
the pricing model needs to be clarified from the interviewer, and therefore you
may ask questions like these:

1. How will pricing be handled?
2. Should we accommodate having different rates for each hour?
 For example, customers will have to pay $4 for the first hour, $3.5
 for the second and third hours, and $2.5 for all the subsequent hours.
3. Will the pricing be the same for the different vehicle types?

Design approach
We are going to design this parking lot system using the bottom-up design
approach. For this purpose, we will follow the steps below:

- Identify and design the smallest components first, like, the vehicle and parking
spot types.
- Use these small components to design bigger components, for example, the payment
system at the exit.
- Repeat the steps above until we design the whole system like the parking lot.

Design pattern
During an interview, it is always a good practice to discuss the design patterns
that a parking lot system falls under. Stating the design patterns gives the
interviewer a positive impression and shows that the interviewee is well-versed
in the advanced concepts of object-oriented design.



Question

Payment & Pricing:
- Hourly pricing model: $4 first hour, $3.50 for hours 2-3, $2.50 for subsequent hours
- Same pricing for all vehicle types (keeping it simple initially)
- Payment methods: Cash, Credit Card at exit (either automated panel or agent)
- Payment happens only at exit

Parking Structure:
- Multi-floor parking lot (3 floors)
- 4 vehicle types: Motorcycle, Car, Van, Truck
- 4 spot types: Motorcycle, Compact, Large, Handicapped
- Vehicle-to-spot mapping rules:
    - Motorcycle → Motorcycle spots only
    - Car → Compact or Large spots
    - Van → Large spots only
    - Truck → Large spots only

Capacity:

- When a spot type is full, vehicles cannot park (no cross-type parking for now)
- System tracks available spots per floor and type.

Problem Statement:
Design a multi-floor parking lot system that supports:

- Vehicle Entry: Issue parking tickets with entry time and assigned spot
- Spot Management: Track and assign appropriate spots based on vehicle type across multiple floors
- Payment Processing: Calculate fees based on parking duration and process payments at exit
- Real-time Tracking: Monitor available spots by type and floor
- Multiple Exit Points: Support both automated panels and staffed exits

Core Use Cases to Implement:

- Park a vehicle (find spot, issue ticket)
- Exit and pay (calculate fee, process payment, free spot)
- Check available spots by type/floor
- Handle full capacity scenarios