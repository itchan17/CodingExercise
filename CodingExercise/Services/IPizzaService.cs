using CodingExercise.Dtos.PizzaDtos;

namespace CodingExercise.Services
{
    public interface IPizzaService
    {
        Task<PizzaResponseDto> AddPizza(AddPizzaDto pizzaDto);
        Task<IEnumerable<PizzaResponseDto>> GetAllPizzas();
        Task<PizzaResponseDto?> UpdatePizzaDetails(Guid id, UpdatePizzaDetailsDto pizzaDto);
        Task<PizzaResponseDto?> UpdatePizzaToppings(Guid id, UpdatePizzaToppingsDto pizzaDto);
        Task<bool> DeletePizza(Guid id);
        Task<bool> HasDuplicateName(string name, Guid? excludeId = null);
    }
}
