using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dtos.PizzaDtos;

public class UpdatePizzaToppingsDto
{
    [Required]
    public List<Guid> Toppings { get; set; } = new List<Guid>();
}
