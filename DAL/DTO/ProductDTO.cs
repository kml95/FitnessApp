using static FitnessApp.Models.Entities.Product;

namespace FitnessApp.DAL.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public ProductCategory Category { get; set; }
    }
}
