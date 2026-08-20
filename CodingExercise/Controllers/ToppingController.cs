using Microsoft.AspNetCore.Mvc;
using CodingExercise.Dtos.ToppingDtos;
using CodingExercise.Services;

namespace CodingExercise.Controllers;

[ApiController]
[Route("api/toppings")]
public class ToppingController : ControllerBase
{
    private readonly IToppingService _toppingService;

    public ToppingController(IToppingService toppingService)
    {
       _toppingService = toppingService;
    }

    [HttpPost]
    public async Task<ActionResult<ToppingResponseDto>> Create(AddToppingDto toppingDto)
    {
        var hasDuplicateName = await _toppingService.HasDuplicateName(toppingDto.Name);

        if (hasDuplicateName)
        {
            return Problem(
                statusCode: StatusCodes.Status409Conflict,
                title: "Duplicate topping name",
                detail: $"A topping with the name '{toppingDto.Name}' already exists."
            );

        }

        var topping = await _toppingService.AddTopping(toppingDto);

        return Ok(topping);
    }

    [HttpGet]
    public async Task<ActionResult<ToppingResponseDto>> GetAll()
    {
        var toppings = await _toppingService.GetAllToppings();

        return Ok(toppings);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ToppingResponseDto>> Update(Guid id, UpdateToppingDto toppingDto)
    {
        var hasDuplicateName = await _toppingService.HasDuplicateName(toppingDto.Name);

        if (hasDuplicateName)
        {
            return Problem(
                statusCode: StatusCodes.Status409Conflict,
                title: "Duplicate topping name",
                detail: $"A topping with the name '{toppingDto.Name}' already exists."
            );

        }

        var topping = await _toppingService.UpdateTopping(id, toppingDto);

        if (topping == null)
        {
            return Problem(
                  statusCode: StatusCodes.Status404NotFound,
                  title: "Topping not found",
                  detail: $"A topping with the ID '{id}' was not found."
             );
        }

        return Ok(topping);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    { 
        var result = await _toppingService.DeleteTopping(id);

        if (!result)
        {
            return Problem(
                 statusCode: StatusCodes.Status404NotFound,
                 title: "Topping not found",
                 detail: $"A topping with the ID '{id}' was not found."
            );
        }

        return NoContent();
    }
}
