using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class MealDiet
    {
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }

        public int DietId { get; set; }
        public virtual Diet Diet { get; set; }
    }
}
