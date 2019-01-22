using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductRepository(ApplicationDbContext appContext, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appContext;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<int> Create(ProductDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Get()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
