using System;
using System.Collections.Generic;

// Enums
public enum VehicleSize { Small, Medium, Large }
public enum ParkingSpotType { Compact, Regular, Large }

// Interfaces
public interface IVehicle
{
    string LicensePlate { get; }
    VehicleSize Size { get; }
}

public interface IParkingSpot
{
    ParkingSpotType Type { get; }
    bool IsOccupied { get; }
    void Occupy(IVehicle vehicle);
    void Vacate();
}

public interface IParkingLot
{
    Ticket ParkVehicle(IVehicle vehicle);
    void RemoveVehicle(Ticket ticket);
}

public interface IPricingStrategy
{
    decimal CalculatePrice(DateTime entryTime, DateTime exitTime);
}

// Classes
public class Vehicle : IVehicle
{
    public string LicensePlate { get; }
    public VehicleSize Size { get; }

    public Vehicle(string licensePlate, VehicleSize size)
    {
        LicensePlate = licensePlate;
        Size = size;
    }
}

public class ParkingSpot : IParkingSpot
{
    public ParkingSpotType Type { get; }
    public bool IsOccupied { get; private set; }
    public IVehicle? OccupyingVehicle { get; private set; }

    public ParkingSpot(ParkingSpotType type)
    {
        Type = type;
        IsOccupied = false;
    }

    public void Occupy(IVehicle vehicle)
    {
        if (IsOccupied)
            throw new InvalidOperationException("Parking spot is already occupied.");
        
        OccupyingVehicle = vehicle;
        IsOccupied = true;
    }

    public void Vacate()
    {
        OccupyingVehicle = null;
        IsOccupied = false;
    }
}

public class Ticket
{
    public Guid Id { get; }
    public IVehicle Vehicle { get; }
    public IParkingSpot Spot { get; }
    public DateTime EntryTime { get; }

    public Ticket(IVehicle vehicle, IParkingSpot spot)
    {
        Id = Guid.NewGuid();
        Vehicle = vehicle;
        Spot = spot;
        EntryTime = DateTime.Now;
    }
}

public class HourlyPricingStrategy : IPricingStrategy
{
    private readonly decimal _hourlyRate;

    public HourlyPricingStrategy(decimal hourlyRate)
    {
        _hourlyRate = hourlyRate;
    }

    public decimal CalculatePrice(DateTime entryTime, DateTime exitTime)
    {
        TimeSpan duration = exitTime - entryTime;
        return Math.Ceiling(duration.TotalHours) * _hourlyRate;
    }
}

public class ParkingLot : IParkingLot
{
    private readonly List<IParkingSpot> _spots;
    private readonly IPricingStrategy _pricingStrategy;

    public ParkingLot(int compactSpots, int regularSpots, int largeSpots, IPricingStrategy pricingStrategy)
    {
        _spots = new List<IParkingSpot>();
        for (int i = 0; i < compactSpots; i++)
            _spots.Add(new ParkingSpot(ParkingSpotType.Compact));
        for (int i = 0; i < regularSpots; i++)
            _spots.Add(new ParkingSpot(ParkingSpotType.Regular));
        for (int i = 0; i < largeSpots; i++)
            _spots.Add(new ParkingSpot(ParkingSpotType.Large));

        _pricingStrategy = pricingStrategy;
    }

    public Ticket ParkVehicle(IVehicle vehicle)
    {
        IParkingSpot? spot = FindAvailableSpot(vehicle.Size);
        if (spot == null)
            throw new InvalidOperationException("No available parking spots.");

        spot.Occupy(vehicle);
        return new Ticket(vehicle, spot);
    }

    public void RemoveVehicle(Ticket ticket)
    {
        if (!ticket.Spot.IsOccupied || ticket.Spot.OccupyingVehicle != ticket.Vehicle)
            throw new InvalidOperationException("Invalid ticket or vehicle not found.");

        ticket.Spot.Vacate();
        decimal price = _pricingStrategy.CalculatePrice(ticket.EntryTime, DateTime.Now);
        Console.WriteLine($"Please pay ${price:F2}");
    }

    private IParkingSpot? FindAvailableSpot(VehicleSize size)
    {
        ParkingSpotType requiredType = size switch
        {
            VehicleSize.Small => ParkingSpotType.Compact,
            VehicleSize.Medium => ParkingSpotType.Regular,
            VehicleSize.Large => ParkingSpotType.Large,
            _ => throw new ArgumentOutOfRangeException(nameof(size))
        };

        return _spots.Find(s => !s.IsOccupied && s.Type >= requiredType);
    }
}

// Usage example
class Program
{
    static void Main()
    {
        IPricingStrategy pricingStrategy = new HourlyPricingStrategy(5.0m); // $5 per hour
        IParkingLot parkingLot = new ParkingLot(5, 10, 3, pricingStrategy);

        IVehicle car = new Vehicle("ABC123", VehicleSize.Medium);
        Ticket ticket = parkingLot.ParkVehicle(car);

        // Simulate time passing
        System.Threading.Thread.Sleep(3000); // Wait for 3 seconds

        parkingLot.RemoveVehicle(ticket);
    }
}
