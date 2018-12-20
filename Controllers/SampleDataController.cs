using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Data;
using FitnessApp.Models.Entities;
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
        public async Task<IEnumerable<string>> GetCarbohydrates()
        {
            var products = await appContext.Meals.Where(m => m.Id == 2).SelectMany(m => m.ProductMeals).Select(pm => pm.Product.Name).ToListAsync();

            return products;
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
