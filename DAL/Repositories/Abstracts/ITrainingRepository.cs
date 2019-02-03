using FitnessApp.DAL.DTO;
using FitnessApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface ITrainingRepository
    {
        Task<TrainingDTO> Get();
        Task<IEnumerable<TrainingDTO>> GetLastAsync(int count);
        Task<IEnumerable<TrainingAnalysisDTO>> GetAllAsync();
        Task<int> Create(TrainingViewModel model);
    }
}
