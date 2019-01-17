using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SampleDataController(ApplicationDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public IActionResult AddAdmin()
        {

            return Ok();
        }

        [HttpGet("carbohydrates")]
        public async Task<IActionResult> GetCarbohydrates()
        {

            var exercises = await appDbContext.Exercises.AsNoTracking().Select(e => new
            {
                chest = appDbContext.Exercises.AsNoTracking().Where(e2 => e2.Muscle == Muscle.CHEST).GroupBy(e2 => e2.Stage)
                .Select(g => new 
                {

                    // Stage = g.Key,
                    Exercises = g.ToList()
                }).Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault()).ToList(),

                chest2 = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.CHEST)
                .GroupBy(e2 => e2.Stage)
                .Select(g => g.ToList().OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                lunch = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.LUNCH).OrderBy(o => Guid.NewGuid()).First(),
                dinner = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.DINNER).OrderBy(o => Guid.NewGuid()).First(),
                snack = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SNACK).OrderBy(o => Guid.NewGuid()).First(),
                supper = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SUPPER).OrderBy(o => Guid.NewGuid()).First(),
                // ifAlreadyExistDiet = appDbContext.Diets.AsNoTracking().Any(d => d.UserId.Equals(HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
            }).FirstOrDefaultAsync();

           // var a = exercises.chest.

            return Ok();
        }

        public class MealsProductsDTO
        {
            //public string MealName { get; set; }
            //public string Proportions { get; set; }
            public string MealName { get; set; }
            public string MealProportions { get; set; }
            public IEnumerable<string> ProductsNames { get; set; }
        }


        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
