using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IProductRepository
    {
        Task<ProductDTO> Get();
        Task<int> Create(ProductDTO model);
        Task<int> Delete(int id);
        Task<int> Update(int id);
    }
}
