using CodingExercise.Data;
using CodingExercise.Dtos.ToppingDtos;
using CodingExercise.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.Services;

public class ToppingService : IToppingService
{
    private readonly AppDbContext _context;

    public ToppingService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ToppingResponseDto> AddTopping(AddToppingDto toppingDto)
    {
        var topping = toppingDto.ToEntity();

        _context.Toppings.Add(topping);

        await _context.SaveChangesAsync();

        var responseDto = topping.ToResponseDto();

        return responseDto;
    }

    public async Task<IEnumerable<ToppingResponseDto>> GetAllToppings()
    {
        var toppings = await _context.Toppings
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        var responseDtos = toppings.Select(t => t.ToResponseDto()).ToList();

        return responseDtos;
    }

    public async Task<ToppingResponseDto?> UpdateTopping(Guid id, UpdateToppingDto toppingDto)
    {
        var topping = await _context.Toppings
            .FindAsync(id);

        if (topping == null)
        {
            return null;
        }

        topping.Name = toppingDto.Name;
        topping.UpdateTimestamps();

        await _context.SaveChangesAsync();

        var responseDto = topping.ToResponseDto();

        return responseDto;
    }

    public async Task<bool> DeleteTopping(Guid id)
    {
        var topping = await _context.Toppings.FindAsync(id);

        if (topping == null)
        {
            return false;
        }

        _context.Toppings.Remove(topping);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> HasDuplicateName(string name, Guid? excludeId = null)
    {
        // Check for duplicate topping name
        // excludeId is use to exclude the current data from being check as duplcate when updating the data
        return await _context.Toppings.AnyAsync(t =>
            t.Name.ToLower().Trim() == name.ToLower().Trim() &&
            (excludeId == null || t.Id != excludeId));
    }
}
