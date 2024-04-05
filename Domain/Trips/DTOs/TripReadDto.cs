using Domain.Persons;

namespace Domain.Trips.DTOs;

public class TripReadDto
{
    public int Id { get; set; }
    public DateTime TripDate { get; set; }
    public ICollection<Person> Passengers { get; set; }
}