using AutoMapper;
using Models;
using DTOs;

namespace Profiles;
public class WorkWayProfile : Profile
{
    public WorkWayProfile()
    {
        CreateMap<PersonCreateDTO, Person>();
    }
}
