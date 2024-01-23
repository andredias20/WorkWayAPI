using AutoMapper;
using DTOs;
using Infraestruture.Repositories;
using System.Drawing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Models;

namespace Infraestruture.Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private WorkWayContext _context;
        private IMapper _mapper;

        public PersonRepository(WorkWayContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<PersonReadDTO>? GetAll(int page, int size)
        {
            var skip = page * size;
            var query = _context.People.Skip(skip).Take(size);
            return _mapper.Map<List<PersonReadDTO>>(query);
        }

        public Person? GetPersonById(int id)
        {
            return _context.People.FirstOrDefault(person => person.Id == id);
        }

        public PersonReadDTO? GetPersonReadDTOById(int id)
        {
            var person = GetPersonById(id);
            return _mapper.Map<PersonReadDTO>(person);
        }

        public Person? CreatePerson(PersonCreateDTO personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _context.People.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person? UpdatePerson(int id, PersonUpdateDTO personUpdateDTO)
        {
            var person = _context.People.FirstOrDefault(person => person.Id == id);
            _mapper.Map(personUpdateDTO, person);
            _context.SaveChanges();
            return person;
        }

        public Person? DeletePerson(int id)
        {
            var person = GetPersonById(id);
            if (person == null) return null;
            _context.People.Remove(person);
            _context.SaveChanges();
            return person;
        }
    }
}
