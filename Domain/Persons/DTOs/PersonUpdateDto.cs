using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class PersonUpdateDto
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
}