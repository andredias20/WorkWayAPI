using AutoMapper;
using Domain.Trips;
using Domain.Trips.DTOs;
using Infraestruture.Repositories.Trips;

namespace Application.Services.Trips;

public class TripService : ITripService
{
    private readonly ITripRepository _repository;
    private readonly IMapper _mapper;
    public TripService(ITripRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public ICollection<TripReadDto> GetAll(int page, int size)
    {
        var skip = page * size;
        var result = _repository.GetAll(skip, size);
        return result == null ? new List<TripReadDto>() : _mapper.Map<ICollection<TripReadDto>>(result);
    }

    public Trip? GetTripById(int id)
    {
        return _repository.GetTripById(id);
    }

    public Trip? CreateTrip(Trip trip)
    {
        throw new NotImplementedException();
    }

    public int? UpdateTrip(Trip trip)
    {
        throw new NotImplementedException();
    }

    public int? DeleteTrip(Trip trip)
    {
        throw new NotImplementedException();
    }
}