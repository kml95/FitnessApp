using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DietsController : Controller
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        public DietsController(ApplicationDbContext appDbContext, UserManager<AppUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<MealsProductsDTO> Get()
        {
            var mealsProducts = await appDbContext.Diets.AsNoTracking()
                .Where(d => d.DietCurrent && d.UserId.Equals(HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .Select(d => new MealsProductsDTO
                {
                    DietName = d.Name,
                    Calories = d.Calories,
                    MealsAmount = d.Meals,
                    UserName = d.User.FirstName,
                    Meals = d.MealDiets
                    .Select(md => md.Meal)
                    .Select(m => new MealsProductsDTO.MealsDTO
                    {
                        Name = m.Name,
                        Type = m.Type.ToString(),
                        Proportions = m.Proportions,
                        ProductsNames = m.ProductMeals.Select(pm => pm.Product.Name).ToList()
                    }).ToList()
                })
                //.Select(m => new MealsProductsDTO
                //{
                //    DietName = m.DietName,
                //    Calories = m.Calories,
                //    MealsAmount = m.MealsAmount,
                //    Meals = m.Meals,
                //    UserName = m.UserName
                //})
                .FirstOrDefaultAsync();

            var mealTypes = mealsProducts.Meals.Select(m => m.Type).ToList();

            var index = 0;
            foreach (var item in mealTypes)
            {
                switch (item)
                {
                    case "BREAKFAST":
                        mealsProducts.Meals.ElementAt(index).Type = "Śniadanie";
                        break;
                    case "LUNCH":
                        mealsProducts.Meals.ElementAt(index).Type = "II śniadanie";
                        break;
                    case "DINNER":
                        mealsProducts.Meals.ElementAt(index).Type = "Obiad";
                        break;
                    case "SNACK":
                        mealsProducts.Meals.ElementAt(index).Type = "Podwieczorek";
                        break;
                    case "SUPPER":
                        mealsProducts.Meals.ElementAt(index).Type = "Kolacja";
                        break;
                    default:
                        mealsProducts.Meals.ElementAt(index).Type = "Typ nieznany";
                        break;
                }
                index++;
            }

            return mealsProducts;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody]DietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meals = await appDbContext.Meals.AsNoTracking().Select(m2 => new
            {
                breakfast = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.BREAKFAST).OrderBy(o => Guid.NewGuid()).First(),
                lunch = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.LUNCH).OrderBy(o => Guid.NewGuid()).First(),
                dinner = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.DINNER).OrderBy(o => Guid.NewGuid()).First(),
                snack = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SNACK).OrderBy(o => Guid.NewGuid()).First(),
                supper = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SUPPER).OrderBy(o => Guid.NewGuid()).First(),
                ifAlreadyExistDiet = appDbContext.Diets.AsNoTracking().Any(d => d.UserId.Equals(HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
            }).FirstOrDefaultAsync();

            var newDiet = new Diet
            {
                Name = model.Name,
                Calories = model.Calories,
                Meals = model.MealsAmount,
                Created = DateTime.UtcNow,
                DietCurrent = true,
                UserId = HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value
            };

            // Get current diet and set prop DietCurrent to false;
            if (meals.ifAlreadyExistDiet)
            {
                var currentDiet = await appDbContext.Diets
                .Where(d => d.UserId.Equals(HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .OrderByDescending(d => d.Created).FirstOrDefaultAsync();

                currentDiet.DietCurrent = false;
            }

            appDbContext.Diets.Add(newDiet);
            await appDbContext.SaveChangesAsync();

            // Create meals to diet
            var mealDiet = new MealDiet
            {
                DietId = newDiet.Id,
                MealId = meals.breakfast.Id
            };
            var mealDiet2 = new MealDiet
            {
                DietId = newDiet.Id,
                MealId = meals.lunch.Id
            };
            var mealDiet3 = new MealDiet
            {
                DietId = newDiet.Id,
                MealId = meals.dinner.Id
            };
            var mealDiet4 = new MealDiet
            {
                DietId = newDiet.Id,
                MealId = meals.snack.Id
            };
            var mealDiet5 = new MealDiet
            {
                DietId = newDiet.Id,
                MealId = meals.supper.Id
            };

            if (model.MealsAmount == 5)
            {
                appDbContext.MealDiets.AddRange(mealDiet, mealDiet2, mealDiet3, mealDiet4, mealDiet5);
            }
            else if (model.MealsAmount == 4)
            {
                appDbContext.MealDiets.AddRange(mealDiet, mealDiet2, mealDiet3, mealDiet5);
            }
            else
            {
                appDbContext.MealDiets.AddRange(mealDiet, mealDiet3, mealDiet5);
            }

            await appDbContext.SaveChangesAsync();

            return Ok();
        }

        public class MealsProductsDTO
        {
            public string DietName { get; set; }
            public int MealsAmount { get; set; }
            public int Calories { get; set; }
            public string UserName { get; set; }
            public IEnumerable<MealsDTO> Meals { get; set; }

            public class MealsDTO
            {
                public string Name { get; set; }
                public string Type { get; set; }
                public string Proportions { get; set; }
                public IEnumerable<string> ProductsNames { get; set; }
            }
        }
    }
}
