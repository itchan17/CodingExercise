using CodingExercise.Dtos.ToppingDtos;
using CodingExercise.Models;

namespace CodingExercise.Mappings;

public static class ToppingMappings
{
    public static Topping ToEntity(this AddToppingDto toppingDto)
    {
       return new Topping
        {
            Name = toppingDto.Name
        };
    }

    public static ToppingResponseDto ToResponseDto(this Topping topping)
    {
        return new ToppingResponseDto
        {
            Id = topping.Id,
            Name = topping.Name,
            CreatedAt = topping.CreatedAt,
            UpdatedAt = topping.UpdatedAt
        };
    }
}
