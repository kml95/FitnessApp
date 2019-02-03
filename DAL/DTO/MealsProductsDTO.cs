using System.Collections.Generic;

namespace FitnessApp.DAL.DTO
{
    public class MealsProductsDTO
    {
        public string DietName { get; set; }
        public int MealsAmount { get; set; }
        public int Calories { get; set; }
        public string Created { get; set; }
        public string UserName { get; set; }
        public IEnumerable<MealsDTO> Meals { get; set; }

        public class MealsDTO
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Proportions { get; set; }
            public string Photo { get; set; }
            public IEnumerable<string> ProductsNames { get; set; }
        }
    }
}
