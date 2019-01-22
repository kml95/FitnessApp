using FitnessApp.DAL.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciesController : ControllerBase
    {
        private readonly IExerciseRepository exerciseRepository;

        public ExerciesController(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }
    }
}
