using Application.Services.Persons;
using Microsoft.AspNetCore.Mvc;
using DTOs;

namespace Host.Controllers;

[ApiController]

[Route("[controller]")] 
public class PersonController : ControllerBase
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] PersonCreateDto personDto)
    { 
        var person = _service.CreatePerson(personDto);
        return CreatedAtAction(
                nameof(GetPersonById),
                new { id = person?.Id },
                person
        );
    }

    [HttpGet]
    public IEnumerable<PersonReadDto> ListPerson([FromQuery()] int page = 0, [FromQuery] int size = 50)
    { 
        return _service.GetAll(page, size);
    }

    [HttpGet("{id}")]
    public IActionResult GetPersonById(int id)
    {
        var person = _service.GetPersonById(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] PersonUpdateDto personUpdateDto)
    {
        var person = _service.UpdatePerson(id, personUpdateDto);
        if (person == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        var person = _service.DeletePerson(id);
        if(person == null) return NotFound();
        return NoContent();
    }

}
