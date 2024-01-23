using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Infraestruture.Repositories;

namespace Controllers;

[ApiController]

[Route("[controller]")]
public class PersonController : ControllerBase
{
    private PersonRepository _personRepository;

    public PersonController(PersonRepository repository)
    {
        _personRepository = repository;
    }

    [HttpPost]
    public IActionResult? AddPerson([FromBody] PersonCreateDTO personDto)
    { 
        var person = _personRepository.CreatePerson(personDto);
        return CreatedAtAction(
                nameof(GetPersonById),
                new { id = person.Id },
                person
        );
    }

    [HttpGet()]
    public IEnumerable<PersonReadDTO> ListPerson([FromQuery()] int page = 0, [FromQuery] int size = 50)
    { 
        return _personRepository.GetAll(page, size);
    }

    [HttpGet("{id}")]
    public IActionResult? GetPersonById(int id)
    {
        var person = _personRepository.GetPersonById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPut("{id}")]
    public IActionResult? UpdatePerson(int id, [FromBody] PersonUpdateDTO personUpdateDTO)
    {
        var person = _personRepository.UpdatePerson(id, personUpdateDTO);
        if (person == null) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult? PathName(int id, JsonPatchDocument<PersonUpdateDTO> path)
    {
        var person = _personRepository.GetPersonReadDTOById(id);
        if(person == null) return NotFound();
        
        var personToUpdate = _mapper.Map<PersonUpdateDTO>(person);
        path.ApplyTo(personToUpdate, ModelState);

        if(!TryValidateModel(personToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(personToUpdate, person);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult? DeletePerson(int id)
    {
        var person = _context.People.FirstOrDefault(person => person.Id == id);
        
        if(person == null) return NotFound();

        _context.People.Remove(person);
        _context.SaveChanges();
        return NoContent();
    }

}
