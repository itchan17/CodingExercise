namespace CodingExercise.Models;

public class Pizza : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Topping> Toppings { get; set; } = new List<Topping>();
}
