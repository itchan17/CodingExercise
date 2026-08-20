using System.ComponentModel.DataAnnotations;

namespace CodingExercise.Dtos.ToppingDtos;

public class UpdateToppingDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
