using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAsync();
        Task<Exercise> CreateAsync(ExerciseDTO exercise);
        Task<Exercise> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ExerciseDTO exercise);
    }
}
