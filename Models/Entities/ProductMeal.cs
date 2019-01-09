using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class ProductMeal
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
    }
}