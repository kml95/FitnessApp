﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IDietRepository dietRepository;

        public DietsController(IDietRepository dietRepository)
        {
            this.dietRepository = dietRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MealsProductsDTO>> Get()
        {
            var model = await dietRepository.Get();

            if (model == null) return NotFound();

            return model;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<MealsProductsDTO>>> GetLast([FromQuery]int count)
        {
            List<MealsProductsDTO> diets = (List<MealsProductsDTO>) await dietRepository.GetLastAsync(count);

            if (diets == null) return NotFound();

            return diets;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<DietAnalysisDTO>>> GetAll()
        {
            List<DietAnalysisDTO> diets = (List<DietAnalysisDTO>) await dietRepository.GetAllAsync();

            if (diets == null) return NotFound();

            return diets;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody]DietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await dietRepository.Create(model);
        }
    }
}
