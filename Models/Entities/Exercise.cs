using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Sets { get; set; }
        //public int Reps { get; set; }
        public int Stage { get; set; }
        public Muscle Muscle { get; set; }

        public virtual ICollection<ExerciseTraining> ExerciseTrainings { get; set; }
    }
    public enum Muscle
    {
        CHEST, BACK, LEGS, SHOULDERS, BICEPS, TRICEPS, ABS
    }
}
