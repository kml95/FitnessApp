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

            modelBuilder.Entity<ProductMeal>().HasKey(pm => new { pm.ProductId, pm.MealId });
            modelBuilder.Entity<MealDiet>().HasKey(md => new { md.MealId, md.DietId });
            modelBuilder.Entity<ExerciseTraining>().HasKey(et => new { et.ExerciseId, et.TrainingId });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                Name = "Wyciskanie sztangi leżąc na ławce poziomej",
                Stage = 1,
                Muscle = Muscle.CHEST
            });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 2,
                Name = "Wyciskanie sztangielek leżąc na ławce poziomej",
                Stage = 2,
                Muscle = Muscle.CHEST
            });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 3,
                Name = "Rozpiętki ze sztangielkami leżąc na ławce skośnej (głową do góry)",
                Stage = 3,
                Muscle = Muscle.CHEST
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 4,
                Name = "Wyciskanie sztangi leżąc na ławce skośnej (głową w górę)",
                Stage = 1,
                Muscle = Muscle.CHEST
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 5,
                Name = "Krzyżowanie linek wyciągu w staniu",
                Stage = 2,
                Muscle = Muscle.CHEST
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 6,
                Name = "Rozpiętki w siadzie na maszynie",
                Stage = 3,
                Muscle = Muscle.CHEST
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 7,
                Name = "Podciąganie na drążku szerokim uchwytem (nachwyt)",
                Stage = 1,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 8,
                Name = "Podciąganie sztangi w opadzie (wiosłowanie)",
                Stage = 2,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 9,
                Name = "Przyciąganie linki wyciągu dolnego w siadzie płaskim",
                Stage = 3,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 10,
                Name = "Martwy ciąg",
                Stage = 1,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 11,
                Name = "Ściąganie drążka wyciągu górnego w siadzie podchwytem",
                Stage = 2,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 12,
                Name = "Podciąganie sztangielek w opadzie (wiosłowanie)",
                Stage = 3,
                Muscle = Muscle.BACK
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 13,
                Name = "Wyciskanie sztangi sprzed głowy",
                Stage = 1,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 14,
                Name = "Unoszenie sztangielek bokiem w górę",
                Stage = 2,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 15,
                Name = "Unoszenie sztangielek w opadzie tułowia",
                Stage = 3,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 16,
                Name = "Wyciskanie sztangielek siedząc",
                Stage = 1,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 17,
                Name = "Podciąganie sztangi wzdłuż tułowia",
                Stage = 2,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 18,
                Name = "Podciąganie sztangielek wzdłuż tułowia w opadzie",
                Stage = 3,
                Muscle = Muscle.SHOULDERS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 19,
                Name = "Przysiady ze sztangą na barkach",
                Stage = 1,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 20,
                Name = "Przysiady wykroczne ze sztangielkami",
                Stage = 2,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 21,
                Name = "Odwodzenie nóg na zewnątrz",
                Stage = 3,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 22,
                Name = "Przysiady ze sztangą trzymaną z przodu",
                Stage = 1,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 23,
                Name = "Prostowanie nóg w siadzie",
                Stage = 2,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 24,
                Name = "Wspięcia na palce stojąc",
                Stage = 3,
                Muscle = Muscle.LEGS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 25,
                Name = "Uginanie ramion ze sztangą stojąc podchwytem",
                Stage = 1,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 26,
                Name = "Uginanie ramion ze sztangielkami stojąc (uchwyt młotkowy)",
                Stage = 2,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 27,
                Name = "Uginanie ramienia ze sztangielką w siadzie (podpora o kolano)",
                Stage = 3,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 28,
                Name = "Uginanie ramion ze sztangą łamaną, stojąc",
                Stage = 1,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 29,
                Name = "Uginanie ramienia ze sztangielką na modlitewniku",
                Stage = 2,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 30,
                Name = "Uginanie ramion ze sztangą nachwytem stojąc",
                Stage = 3,
                Muscle = Muscle.BICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 31,
                Name = "Prostowanie ramion na wyciągu stojąc",
                Stage = 1,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 32,
                Name = "Wyciskanie leżąc na ławce poziomej wąskim uchwytem",
                Stage = 2,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 33,
                Name = "Wyciskanie francuskie jednorącz sztangielki w siadzie",
                Stage = 3,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 34,
                Name = "Wyciskanie francuskie sztangi leżąc",
                Stage = 1,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 35,
                Name = "Pompki na poręczach",
                Stage = 2,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 36,
                Name = "Prostowanie ramienia ze sztangielką w opadzie tułowia",
                Stage = 3,
                Muscle = Muscle.TRICEPS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 37,
                Name = "Unoszenie nóg w zwisie na drążku",
                Stage = 1,
                Muscle = Muscle.ABS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 38,
                Name = "Brzuszki",
                Stage = 2,
                Muscle = Muscle.ABS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 39,
                Name = "Skłony boczne ze sztangielkami",
                Stage = 3,
                Muscle = Muscle.ABS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 40,
                Name = "Przyciąganie kolan do klatki w zwisie na drążku",
                Stage = 1,
                Muscle = Muscle.ABS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 41,
                Name = "Skłony tułowia na ławce skośnej",
                Stage = 2,
                Muscle = Muscle.ABS
            });

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 42,
                Name = "Unoszenie nóg leżąc na podłodze",
                Stage = 3,
                Muscle = Muscle.ABS
            });
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<ProductMeal> ProductMeals { get; set; }
        public virtual DbSet<MealDiet> MealDiets { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<ExerciseTraining> ExerciseTrainings { get; set; }
    }
}
