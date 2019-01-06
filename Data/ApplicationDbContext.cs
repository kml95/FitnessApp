using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductMeal>().HasKey(sc => new { sc.ProductId, sc.MealId });
            modelBuilder.Entity<MealDiet>().HasKey(sc => new { sc.MealId, sc.DietId });


        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<ProductMeal> ProductMeals { get; set; }
        public virtual DbSet<MealDiet> MealDiets { get; set; }
    }
}
