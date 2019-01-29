using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository exerciseRepository;

        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> Get()
        {
            List<ExerciseDTO> exercises = (List<ExerciseDTO>) await exerciseRepository.GetAsync();

            if (exercises == null) return NotFound();

            return exercises;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ExerciseDTO>>> GetRange([FromQuery]int skip, [FromQuery]int take)
        {
            List<ExerciseDTO> exercises = (List<ExerciseDTO>) await exerciseRepository.GetAsync(skip, take);

            if (exercises == null) return NotFound();

            return exercises;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> GetIdByName([FromQuery]string name)
        {
            var id = await exerciseRepository.GetIdByNameAsync(name);

            if (id == 0) return NotFound();

            return id;
        }


        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<int>> Count()
        {
            return await exerciseRepository.CountAsync();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Exercise>> Create([FromBody] ExerciseDTO exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exercise newExercise = await exerciseRepository.CreateAsync(exercise);

            return CreatedAtAction("Get", new { id = newExercise.Id }, newExercise);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Exercise>> Delete(int id)
        {
            var exercise = await exerciseRepository.DeleteAsync(id);

            if (exercise == null) NotFound();

            return exercise;
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Update(int id, [FromBody]ExerciseDTO exercise)
        {
            bool ifUpdated = await exerciseRepository.UpdateAsync(id, exercise);

            if (!ifUpdated) return BadRequest(); 

            return NoContent();
        }
    }
}
