using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<ExerciseDTO>> GetAsync();
        Task<IEnumerable<ExerciseDTO>> GetAsync(int skip, int take);
        Task<int> GetIdByNameAsync(string name);
        Task<int> CountAsync();
        Task<Exercise> CreateAsync(ExerciseDTO exercise);
        Task<Exercise> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ExerciseDTO exercise);
    }
}
