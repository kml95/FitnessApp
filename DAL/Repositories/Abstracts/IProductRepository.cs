using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> CreateAsync(ProductDTO model);
        Task<Product> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ProductDTO product);
    }
}
