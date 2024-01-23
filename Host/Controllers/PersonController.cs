using Microsoft.AspNetCore.Mvc;
using DTOs;
using Infraestruture.Repositories.Persons;

namespace Host.Controllers;

[ApiController]

[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonRepository _personRepository;

    public PersonController(PersonRepository repository)
    {
        _personRepository = repository;
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonCreateDTO personDto)
    { 
        var person = _personRepository.CreatePerson(personDto);
        return CreatedAtAction(
                nameof(GetPersonById),
                new { id = person?.Id },
                person
        );
    }

    [HttpGet()]
    public IEnumerable<PersonReadDTO>? ListPerson([FromQuery()] int page = 0, [FromQuery] int size = 50)
    { 
        return _personRepository.GetAll(page, size);
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonById(int id)
    {
        var person = _personRepository.GetPersonById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] PersonUpdateDTO personUpdateDto)
    {
        var person = _personRepository.UpdatePerson(id, personUpdateDto);
        if (person == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        var person = _personRepository.DeletePerson(id);
        if(person == null) return NotFound();
        return NoContent();
    }

}
