using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;
using AutoMapper;

namespace Controllers;

[ApiController]

[Route("[controller]")]
public class PersonController : ControllerBase
{

    private WorkWayContext _context;
    private IMapper _mapper;

    public PersonController(WorkWayContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult? AddPerson([FromBody] PersonCreateDTO personDto)
    {
        Person person = _mapper.Map<Person>(personDto);
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
