using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IDietRepository
    {
        long Add(string name, int calories, int meals);
    }
}
