using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext appContext;
        private readonly UserManager<AppUser> userManager;

        public AccountsController(UserManager<AppUser> userManager, ApplicationDbContext appContext)
        {
            this.userManager = userManager;
            this.appContext = appContext;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = new AppUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName }; 

            var result = await userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Errors.AddErrorsToModelState(result, ModelState));
            }
            else
            {
                var result2 = await userManager.AddToRoleAsync(userIdentity, "User");
                if (!result2.Succeeded) return BadRequest(Errors.AddErrorsToModelState(result2, ModelState));
            }
            return Ok();
        }
    }
}