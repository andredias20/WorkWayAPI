using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs;
public class PersonCreateDTO
{
    [Required(ErrorMessage = "O nome é obrigatorio")]
    public required string Name { get; set; }
}
