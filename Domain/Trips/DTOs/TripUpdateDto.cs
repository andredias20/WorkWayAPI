using Models;

namespace Domain.Trips.DTOs;

public class TripUpdateDto
{
    public DateTime TripDate { get; set; }
    public ICollection<Person> Passengers { get; set; }
}