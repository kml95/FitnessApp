using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext AppContext;

        public DietRepository(ApplicationDbContext appContext)
        {
            this.AppContext = appContext;
        }

        public long Add(string name, int calories, int meals)
        {
            throw new NotImplementedException();
        }
    }
}
