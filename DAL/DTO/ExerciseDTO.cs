using FitnessApp.Models.Entities;

namespace FitnessApp.DAL.DTO
{
    public class ExerciseDTO
    {
        public string Name { get; set; }
        public int Stage { get; set; }
        public Muscle Muscle { get; set; }
    }
}
