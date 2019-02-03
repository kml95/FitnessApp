using FitnessApp.DAL.DTO;
using FitnessApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IDietRepository
    {
        Task<MealsProductsDTO> Get();
        Task<IEnumerable<MealsProductsDTO>> GetLastAsync(int count);
        Task<IEnumerable<DietAnalysisDTO>> GetAllAsync();
        Task<int> Create(DietViewModel model);
    }
}
