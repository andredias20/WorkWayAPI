using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]

[Route("[controller]")]
public class PersonController : ControllerBase
{

    private WorkWayContext _context;

    public PersonController(WorkWayContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult? AddPerson([FromBody] Person person)
    {
        _context.People.Add(person);
        _context.SaveChanges();
        return CreatedAtAction(
                nameof(GetPersonById),
                new { id = person.Id },
                person
        );
    }

    [HttpGet()]
    public IEnumerable<Person> ListPerson([FromQuery()] int page = 0, [FromQuery] int size = 50)
    {
        return _context.People.Skip(page).Take(size);
    }

    [HttpGet("{id}")]
    public IActionResult? GetPersonById(int id)
    {
        var person = _context.People.FirstOrDefault(person => person.Id == id);
        if (person == null) return NotFound();
        return Ok(person);
    }
}
