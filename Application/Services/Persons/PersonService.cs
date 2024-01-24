using AutoMapper;
using DTOs;
using Infraestruture.Repositories.Persons;
using Models;

namespace Application.Services.Persons;

public class PersonService : IPersonService
{

    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public List<PersonReadDto>? GetAll(int page, int size)
    {
        var query = _repository.GetAll(page, size);
        return _mapper.Map<List<PersonReadDto>>(query);
    }

    public Person? GetPersonById(int id)
    {
        return _repository.GetPersonById(id);
    }

    public PersonReadDto? GetPersonReadDtoById(int id)
    {            
        var person = GetPersonById(id);
        return _mapper.Map<PersonReadDto>(person);
    }

    public Person? CreatePerson(PersonCreateDto personCreateDto)
    {
        var person = _mapper.Map<Person>(personCreateDto);
        return _repository.CreatePerson(person);
    }

    public Person? UpdatePerson(int id, PersonUpdateDto personUpdateDto)
    {
        var person = GetPersonById(id);
        
        var mappedPerson = _mapper.Map(personUpdateDto, person);
        return _repository.UpdatePerson(mappedPerson);
    }

    public Person? DeletePerson(int id)
    {
        var person = GetPersonById(id);
        if (person == null) return null;
        return _repository.DeletePerson(person);
    }
}