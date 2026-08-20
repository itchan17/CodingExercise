using CodingExercise.Data;
using CodingExercise.Dtos.PizzaDtos;
using CodingExercise.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Services;

public class PizzaService : IPizzaService
{
    private readonly AppDbContext _context;

    public PizzaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PizzaResponseDto> AddPizza(AddPizzaDto pizzaDto)
    {
        var toppings = await _context.Toppings
            .Where(t => pizzaDto.Toppings.Contains(t.Id))
            .ToListAsync();

        var pizza = pizzaDto.ToEntity(toppings);

        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();

        var responseDto = pizza.ToResponseDto();

        return responseDto;
    }

    public async Task<IEnumerable<PizzaResponseDto>> GetAllPizzas()
    {
        var pizzas = await _context.Pizzas
            .Include(p => p.Toppings)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        var responseDtos = pizzas.Select(p => p.ToResponseDto());

        return responseDtos;
    }

    public async Task<PizzaResponseDto?> UpdatePizzaDetails(Guid id, UpdatePizzaDetailsDto pizzaDto)
    {
        var pizza = await _context.Pizzas
            .Include(p => p.Toppings)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pizza is null)
        {
            return null;
        }

        pizza.Name = pizzaDto.Name;
        pizza.Price = pizzaDto.Price;
        pizza.UpdateTimestamps();

        await _context.SaveChangesAsync();

        var responseDto = pizza.ToResponseDto();

        return responseDto;
    }

    public async Task<PizzaResponseDto?> UpdatePizzaToppings(Guid id, UpdatePizzaToppingsDto pizzaDto)
    {
        var pizza = await _context.Pizzas
            .Include(p => p.Toppings)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pizza is null)
        {
            return null;
        }

        var toppings = await _context.Toppings
            .Where(t => pizzaDto.Toppings.Contains(t.Id))
            .ToListAsync();

        pizza.Toppings = toppings;
        pizza.UpdateTimestamps();

        await _context.SaveChangesAsync();

        var responseDto = pizza.ToResponseDto();

        return responseDto;
    }

    public async Task<bool> DeletePizza(Guid id)
    {
        var pizza = await _context.Pizzas
            .FindAsync(id);

        if (pizza is null)
        {
            return false;
        }

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> HasDuplicateName(string name, Guid? excludeId = null)
    {
        // Check for duplicate pizza name
        // excludeId is use to exclude the current data from being check as duplcate when updating the data
        return await _context.Pizzas.AnyAsync(p => 
            p.Name.ToLower().Trim() == name.ToLower().Trim() && 
            (excludeId == null || p.Id != excludeId));
    }
}
