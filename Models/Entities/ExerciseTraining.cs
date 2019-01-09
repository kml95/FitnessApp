using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class ExerciseTraining
    {
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
