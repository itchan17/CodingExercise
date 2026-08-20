namespace CodingExercise.Models
{
    public class Topping : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
