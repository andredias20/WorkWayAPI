using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Persons;


namespace Domain.Trips;

public class Trip
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime TripDate { get; set; }
    public ICollection<Person> Passengers { get; set; }
    
}