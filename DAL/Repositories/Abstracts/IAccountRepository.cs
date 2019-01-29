using FitnessApp.DAL.DTO;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories.Abstracts
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AppUserDTO>> GetAsync();
        Task<IEnumerable<AppUserDTO>> GetAsync(int skip, int take);
        Task<string> GetIdByUserNameAsync(string name);
        Task<int> CountAsync();
        Task<AppUser> CreateAsync(RegistrationViewModel model);
        Task<AppUserDTO> DeleteAsync(string id);
        Task<bool> UpdateAsync(string id, AppUserDTO product);
    }
}
