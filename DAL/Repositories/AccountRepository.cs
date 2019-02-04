using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> userManager;

        public AccountRepository(ApplicationDbContext appContext, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<AppUserDTO>> GetAsync()
        {
            return await userManager
                .Users
                .AsNoTracking()
                .Select(u => new AppUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppUserDTO>> GetAsync(int skip, int take)
        {
            return await userManager
                .Users
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .Select(u => new AppUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<string> GetIdByUserNameAsync(string userName)
        {
            return await userManager
                .Users
                .AsNoTracking()
                .Where(u => u.UserName.Equals(userName))
                .Select(e => e.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<AppUserDTO> GetByUserNameAsync(string userName)
        {
            return await userManager
                .Users
                .AsNoTracking()
                .Where(u => u.UserName.Equals(userName))
                .Select(e => new AppUserDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    UserName = e.UserName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync()
        {
            return await userManager
                .Users
                .AsNoTracking()
                .CountAsync();
        }
        
        public async Task<AppUser> CreateAsync(RegistrationViewModel user)
        {
            var newUser = new AppUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Email = user.Email
            };

            if (await userManager.CreateAsync(newUser, user.Password) != IdentityResult.Success) return null;
            if (await userManager.AddToRoleAsync(newUser, "User") != IdentityResult.Success) return null;

            return newUser;
        }

        public async Task<bool> UpdateAsync(string id, AppUserDTO user)
        {
            var userToUpdate = await userManager.FindByIdAsync(id);

            if (userToUpdate == null) return false;

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Email = user.Email;

            await userManager.UpdateAsync(userToUpdate);

            return true;
        }

        public async Task<AppUserDTO> DeleteAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null) return null;

            await userManager.DeleteAsync(user);

            return new AppUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };
        }
    }
}
