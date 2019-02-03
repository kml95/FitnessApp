using FitnessApp.Models.Entities;
using System.Collections.Generic;
using static FitnessApp.Models.Entities.Training;

namespace FitnessApp.DAL.DTO
{
    public class TrainingDTO
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public string Created { get; set; }
        public TrainingAim Aim { get; set; }
        public string UserName { get; set; }
        public IEnumerable<ExerciseDTO> Exercises { get; set; }

        public class ExerciseDTO
        {
            public string Name { get; set; }
            public int Stage { get; set; }
            public Muscle Muscle { get; set; }
        }
    }
}
