using CodingExercise.Dtos.PizzaDtos;
using CodingExercise.Dtos.ToppingDtos;
using CodingExercise.Models;

namespace CodingExercise.Mappings;

public static class PizzaMappings
{
    public static Pizza ToEntity(this AddPizzaDto pizzaDto, List<Topping> toppings)
    {
        return new Pizza
        {
            Name = pizzaDto.Name,
            Price = pizzaDto.Price,
            Toppings = toppings
        };
    }

    public static PizzaResponseDto ToResponseDto(this Pizza pizza)
    {
        return new PizzaResponseDto
        {
            Id = pizza.Id,
            Name = pizza.Name,
            Price = pizza.Price,
            Toppings = pizza.Toppings.Select(t => new ToppingResponseDto
            {
                Id = t.Id,
                Name = t.Name,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            }).ToList(),
            CreatedAt = pizza.CreatedAt,
            UpdatedAt = pizza.UpdatedAt
        };
    }
}
