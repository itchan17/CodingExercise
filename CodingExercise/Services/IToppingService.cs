using CodingExercise.Dtos.ToppingDtos;

namespace CodingExercise.Services;

public interface IToppingService
{
    Task<ToppingResponseDto> AddTopping(AddToppingDto toppingDto);
    Task<IEnumerable<ToppingResponseDto>> GetAllToppings();
    Task<ToppingResponseDto?> UpdateTopping(Guid id, UpdateToppingDto toppingDto);
    Task<bool> DeleteTopping(Guid id);
    Task<bool> HasDuplicateName(string name, Guid? excludeId = null);
}
