using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class PersonReadDto
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}