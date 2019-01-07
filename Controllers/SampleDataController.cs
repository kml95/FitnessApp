using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : Controller
    {
        private readonly ApplicationDbContext appContext;

        public SampleDataController(ApplicationDbContext appContext)
        {
            this.appContext = appContext;
        }

        [HttpGet("carbohydrates")]
        public async Task<List<MealsProductsDTO>> GetCarbohydrates()
        {

            var products = await appContext.Users
                .SelectMany(u => u.Diets).Where(d => d.DietCurrent)  //.Where(d => d.UserId.Equals(HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .SelectMany(d => d.MealDiets)
                .Select(md => md.Meal)
                .Select(m => new MealsProductsDTO
                {
                    MealName = m.Name,
                    MealProportions = m.Proportions,
                    ProductsNames = m.ProductMeals.Select(pm => pm.Product.Name).ToList()
                })
                //.SelectMany(m => m.ProductMeals)
                //.Select(pm => pm.Product.Name)
                .ToListAsync();


            return products;
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
