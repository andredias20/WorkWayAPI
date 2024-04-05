using Domain.Persons;

namespace Infraestruture.Repositories.Persons
{
    public interface IPersonRepository
    {
        public IQueryable<Person>? GetAll(int page, int size);
        Person? GetPersonById(int id);
        Person? CreatePerson(Person personCreateDto);
        Person? UpdatePerson(Person personUpdateDto);
        Person? DeletePerson(Person id);
    }
}
