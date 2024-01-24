using AutoMapper;
using Domain.Trips;
using Domain.Trips.DTOs;

namespace Profiles;

public class TripMapProfile : Profile
{
    public TripMapProfile()
    {
        CreateMap<TripCreateDto, Trip>();
        CreateMap<TripUpdateDto, Trip>();
        CreateMap<Trip, TripUpdateDto>();
        CreateMap<Trip, TripReadDto>();
    }
    
}