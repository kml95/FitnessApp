using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IDietRepository
    {
        Task<MealsProductsDTO> Get();
        Task<int> Create(DietViewModel model);
    }
}
