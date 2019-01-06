using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Meals { get; set; }
        public DateTime Created { get; set; }
        public bool DietCurrent { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<MealDiet> MealDiets { get; set; }
    }
}
