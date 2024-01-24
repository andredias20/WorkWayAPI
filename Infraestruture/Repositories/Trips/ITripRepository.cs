using Domain.Trips;
using Domain.Trips.DTOs;

namespace Infraestruture.Repositories.Trips;

public interface ITripRepository
{
    IQueryable<Trip>? GetAll(int skip, int size);
    Trip? GetTripById(int id);
    Trip? CreateTrip(Trip trip);
    int? UpdateTrip(Trip trip);
    int? DeleteTrip(Trip trip);
}