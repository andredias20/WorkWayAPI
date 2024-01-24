using Domain.Trips;
using Infraestruture.Context;

namespace Infraestruture.Repositories.Trips;

public class TripRepository : ITripRepository
{
    private readonly WorkWayContext _context;

    public TripRepository(WorkWayContext context)
    {
        _context = context;
    }
    
    public IQueryable<Trip>? GetAll(int skip, int size)
    {
        return _context.Trip.Skip(skip).Take(size);
    }

    public Trip? GetTripById(int id)
    {
        return _context.Trip.FirstOrDefault(trip => trip.Id == id);
    }

    public Trip? CreateTrip(Trip trip)
    {
        _context.Trip.Add(trip);
        _context.SaveChanges();
        return trip;
    }

    public int? UpdateTrip(Trip trip)
    {
        _context.Trip.Update(trip);
        return _context.SaveChanges();
    }

    public int? DeleteTrip(Trip trip)
    {
        _context.Trip.Remove(trip);
        return _context.SaveChanges();
    }
}