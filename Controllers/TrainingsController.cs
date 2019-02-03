using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingRepository trainingRepository;

        public TrainingsController(ITrainingRepository trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TrainingDTO>> Get()
        {
            var model = await trainingRepository.Get();

            if (model == null) return NotFound();

            return model;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetLast([FromQuery]int count)
        {
            List<TrainingDTO> model = (List<TrainingDTO>) await trainingRepository.GetLastAsync(count);

            if (model == null) return NotFound();

            return model;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<TrainingAnalysisDTO>>> GetAll()
        {
            List<TrainingAnalysisDTO> trainings = (List<TrainingAnalysisDTO>) await trainingRepository.GetAllAsync();

            if (trainings == null) return NotFound();

            return trainings;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody]TrainingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await trainingRepository.Create(model);
        }
    }
}
