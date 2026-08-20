using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dtos.PizzaDtos;

public class UpdatePizzaDetailsDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, 99999.99)]
    public decimal Price { get; set; }
}
