using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Proportions { get; set; }
        public MealType Type { get; set; }
        public string Photo { get; set; }


        public virtual ICollection<ProductMeal> ProductMeals { get; set; }
        public virtual ICollection<MealDiet> MealDiets { get; set; }

        public enum MealType
        {
            BREAKFAST, LUNCH, DINNER, SNACK, SUPPER
        }
    }
}
