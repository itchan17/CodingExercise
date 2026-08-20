using CodingExercise.Dtos.ToppingDtos;

namespace CodingExercise.Dtos.PizzaDtos;

public class PizzaResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<ToppingResponseDto> Toppings { get; set; } = new List<ToppingResponseDto>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
