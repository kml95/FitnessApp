using static FitnessApp.Models.Entities.Training;

namespace FitnessApp.ViewModels
{
    public class TrainingViewModel
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public TrainingAim Aim { get; set; }
    }
}
