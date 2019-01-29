using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AppUserDTO>>> Get()
        {
            List<AppUserDTO> users = (List<AppUserDTO>)await accountRepository.GetAsync();

            if (users == null) return NotFound();

            return users;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AppUserDTO>>> GetRange([FromQuery]int skip, [FromQuery]int take)
        {
            List<AppUserDTO> users = (List<AppUserDTO>)await accountRepository.GetAsync(skip, take);

            if (users == null) return NotFound();

            return users;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetIdByUserName([FromQuery]string name)
        {
            string id = await accountRepository.GetIdByUserNameAsync(name);

            if (id.Equals(0)) return NotFound();

            return Ok(new { Id = id });
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> Count()
        {
            return await accountRepository.CountAsync();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<AppUserDTO>> Register([FromBody]RegistrationViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AppUser newUser = await accountRepository.CreateAsync(user);

            if (newUser == null) return BadRequest();

            return CreatedAtAction
                ("Get",
                new { id = newUser.Id },
                new AppUserDTO
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    UserName = newUser.UserName,
                    Email = newUser.Email
                });
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AppUserDTO>> Delete([FromQuery]string id)
        {
            var user = await accountRepository.DeleteAsync(id);

            if (user == null) NotFound();

            return user;
        }

        [HttpPut("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Update([FromQuery]string id, [FromBody]AppUserDTO user)
        {
            bool ifUpdated = await accountRepository.UpdateAsync(id, user);

            if (!ifUpdated) return BadRequest();

            return NoContent();
        }
    }
}