using Models;

namespace Domain.Trips.DTOs;

public class TripCreateDto
{
    public DateTime TripDate = DateTime.Now;
    public ICollection<Person> Passengers { get; set; }
}