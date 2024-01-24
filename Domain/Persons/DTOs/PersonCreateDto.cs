using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class PersonCreateDto
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
}