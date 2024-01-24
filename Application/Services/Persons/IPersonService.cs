using DTOs;
using Models;

namespace Application.Services.Persons;

public interface IPersonService
{
    List<PersonReadDto>? GetAll(int page, int size);
    Person? GetPersonById(int id);
    PersonReadDto? GetPersonReadDtoById(int id);
    Person? CreatePerson(PersonCreateDto personCreateDto);
    Person? UpdatePerson(int id, PersonUpdateDto personUpdateDto);
    Person? DeletePerson(int id);
}