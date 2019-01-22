using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IExerciseRepository
    {
        Task<ExerciseDTO> Get();
        Task<int> Create(ExerciseDTO model);
        Task<int> Delete(int id);
        Task<int> Update(int id);
    }
}
