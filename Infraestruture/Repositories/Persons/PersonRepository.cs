using AutoMapper;
using DTOs;
using Infraestruture.Context;
using Domain.Persons;

namespace Infraestruture.Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private readonly WorkWayContext _context;

        public PersonRepository(WorkWayContext context)
        {
            _context = context;
        }
        
        public IQueryable<Person>? GetAll(int skip, int size)
        {
            return _context.Person.Skip(skip).Take(size);
        }

        public Person? GetPersonById(int id)
        {
            return _context.Person.FirstOrDefault(person => person.Id == id);
        }

        public Person? CreatePerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person? UpdatePerson(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return person;
        }

        public Person? DeletePerson(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
            return person;
        }
    }
}
