using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class PersonReadDTO
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}