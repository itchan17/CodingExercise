using Microsoft.EntityFrameworkCore;
using CodingExercise.Models;

namespace CodingExercise.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pizza>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Topping>()
            .HasIndex(t => t.Name)
            .IsUnique();
    }
}
