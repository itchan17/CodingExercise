using CodingExercise.Dtos.PizzaDtos;
using CodingExercise.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingExercise.Controllers
{
    [ApiController]
    [Route("api/pizzas")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpPost]
        public async Task<ActionResult<PizzaResponseDto>> Create(AddPizzaDto pizzaDto)
        {
            var hasDuplicateName = await _pizzaService.HasDuplicateName(pizzaDto.Name);

            if (hasDuplicateName)
            {
                return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Duplicate pizza name",
                    detail: $"A pizza with the name '{pizzaDto.Name}' already exists."
                );
            }

            var pizza = await _pizzaService.AddPizza(pizzaDto);

            return Ok(pizza);
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaResponseDto>>> GetAll()
        {
            var pizzas = await _pizzaService.GetAllPizzas();

            return Ok(pizzas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PizzaResponseDto>> Update(Guid id, UpdatePizzaDetailsDto pizzaDto)
        {
            var hasDuplicateName = await _pizzaService.HasDuplicateName(pizzaDto.Name, id);

            if (hasDuplicateName)
            {
                return Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Duplicate pizza name",
                    detail: $"A pizza with the name '{pizzaDto.Name}' already exists."
                );
            }

            var pizza = await _pizzaService.UpdatePizzaDetails(id, pizzaDto);

            if (pizza is null)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Pizza not found",
                    detail: $"A pizza with the ID '{id}' was not found."
                );
            }

            return Ok(pizza);
        }

        [HttpPut("{id}/toppings")]
        public async Task<ActionResult<PizzaResponseDto>> UpdateToppings(Guid id, UpdatePizzaToppingsDto pizzaDto) 
        {

            var pizza = await _pizzaService.UpdatePizzaToppings(id, pizzaDto);

            if (pizza is null)
            {
                return Problem(
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Pizza not found",
                    detail: $"A pizza with the ID '{id}' was not found."
                );
            }

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            var result = await _pizzaService.DeletePizza(id);

            if (!result)
            {
                return Problem(
                     statusCode: StatusCodes.Status404NotFound,
                     title: "Pizza not found",
                     detail: $"A pizza with the ID '{id}' was not found."
                 );
            }

            return NoContent();
        }

    }
}
