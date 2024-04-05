using Domain.Trips;
using Domain.Trips.DTOs;

namespace Application.Services.Trips;

public interface ITripService
{
    ICollection<TripReadDto> GetAll(int page, int size);
    Trip? GetTripById(int id);
    Trip? CreateTrip(Trip trip);
    int? UpdateTrip(Trip trip);
    int? DeleteTrip(Trip trip);
}