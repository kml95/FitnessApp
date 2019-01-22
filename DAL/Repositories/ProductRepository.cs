using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public ProductRepository(ApplicationDbContext appContext)
        {
            this.appDbContext = appContext;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await appDbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> CreateAsync(ProductDTO product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Calories = product.Calories,
                Carbohydrates = product.Carbohydrates,
                Protein = product.Protein,
                Fat = product.Fat,
                Category = product.Category
            };

            appDbContext.Products.Add(newProduct);
            await appDbContext.SaveChangesAsync();

            return newProduct;
        }

        public async Task<bool> UpdateAsync(int id, ProductDTO product)
        {
            var productToUpdate = await appDbContext.Products.FindAsync(id);

            if (productToUpdate == null) return false;

            productToUpdate.Name = product.Name;
            productToUpdate.Calories = product.Calories;
            productToUpdate.Carbohydrates = product.Carbohydrates;
            productToUpdate.Protein = product.Protein;
            productToUpdate.Fat = product.Fat;
            productToUpdate.Category = product.Category;

            appDbContext.Entry(productToUpdate).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var product = await appDbContext.Products.FindAsync(id);

            if (product == null) return null;

            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();

            return product;
        }
    }
}
