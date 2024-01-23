using System.ComponentModel.DataAnnotations;

namespace DTOs;
public class PersonCreateDTO
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
}