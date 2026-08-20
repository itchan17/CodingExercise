using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dtos.ToppingDtos;

public class AddToppingDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
