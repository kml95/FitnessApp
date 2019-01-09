using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Models.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public DateTime Created { get; set; }
        public bool TrainingCurrent { get; set; }
        public TrainingAim Aim { get; set; }
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<ExerciseTraining> ExerciseTrainings { get; set; }

        public enum TrainingAim
        {
            MASS, REDUCTION, STRENGTH
        }
    }
}
