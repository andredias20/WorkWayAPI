using AutoMapper;
using Models;
using DTOs;

namespace Profiles;

public class PersonMapProfile : Profile
{
    public PersonMapProfile()
    {
        CreateMap<PersonCreateDto, Person>();
        CreateMap<PersonUpdateDto, Person>();
        CreateMap<Person, PersonUpdateDto>();
        CreateMap<Person, PersonReadDto>();
    }
}
