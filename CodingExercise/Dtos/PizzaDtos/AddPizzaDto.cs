using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingExercise.Dtos.PizzaDtos;

public class AddPizzaDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, 99999.99)]
    public decimal Price { get; set; }

    [Required]
    public List<Guid> Toppings { get; set; } = new List<Guid>();
}
