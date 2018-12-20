using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public ProductCategory Category { get; set; }

        public virtual ICollection<ProductMeal> ProductMeals { get; set; }

        public enum ProductCategory
        {
            CARBOHYDRATES, PROTEIN, FAT
        }
    }
}
