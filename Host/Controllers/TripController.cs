using Application.Services.Trips;
using Domain.Trips.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripService _service;

    public TripController(ITripService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public ICollection<TripReadDto> GetAll([FromQuery()] int page = 0, int size = 50)
    {
        return  _service.GetAll(page, size);
    }
    

}