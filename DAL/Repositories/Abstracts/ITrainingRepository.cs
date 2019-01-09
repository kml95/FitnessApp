using FitnessApp.DAL.DTO;
using FitnessApp.ViewModels;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface ITrainingRepository
    {
        Task<TrainingDTO> Get();
        Task<int> Create(TrainingViewModel model);
    }
}
