using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FitnessApp.DAL.DTO.MealsProductsDTO;

namespace FitnessApp.DAL.Repositories
{
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DietRepository(ApplicationDbContext appContext, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appContext;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<MealsProductsDTO> Get()
        {
            var mealsProducts = await appDbContext.Diets.AsNoTracking()
                .Where(d => d.DietCurrent && d.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .Select(d => new MealsProductsDTO
                {
                    DietName = d.Name,
                    Calories = d.Calories,
                    MealsAmount = d.Meals,
                    Created = d.Created.ToString("yyyy:MM:dd HH:mm"),
                    UserName = d.User.FirstName,
                    Meals = d.MealDiets
                    .Select(md => md.Meal)
                    .Select(m => new MealsDTO
                    {
                        Name = m.Name,
                        Type = m.Type.ToString(),
                        Proportions = m.Proportions,
                        Photo = m.Photo,
                        ProductsNames = m.ProductMeals.Select(pm => pm.Product.Name).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (mealsProducts == null) return null;
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

        public async Task<IEnumerable<MealsProductsDTO>> GetLastAsync(int count)
        {
            var mealsProducts = await appDbContext.Diets.AsNoTracking()
                .Where(d => !d.DietCurrent && d.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .OrderByDescending(d => d.Created)
                .Take(count)
                .Select(d => new MealsProductsDTO
                {
                    DietName = d.Name,
                    Calories = d.Calories,
                    MealsAmount = d.Meals,
                    Created = d.Created.ToString("yyyy:MM:dd HH:mm"),
                    UserName = d.User.FirstName,
                    Meals = d.MealDiets
                    .Select(md => md.Meal)
                    .Select(m => new MealsDTO
                    {
                        Name = m.Name,
                        Type = m.Type.ToString(),
                        Proportions = m.Proportions,
                        Photo = m.Photo,
                        ProductsNames = m.ProductMeals.Select(pm => pm.Product.Name).ToList()
                    }).ToList()
                })
                .ToListAsync();

            if (mealsProducts == null) return null;

            var indexMealProducts = 0;
            foreach (var item in mealsProducts)
            {
                var mealTypes = item.Meals.Select(m => m.Type).ToList();

                var indexMealTypes = 0;
                foreach (var item2 in mealTypes)
                {
                    switch (item2)
                    {
                        case "BREAKFAST":
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "Śniadanie";
                            break;
                        case "LUNCH":
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "II śniadanie";
                            break;
                        case "DINNER":
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "Obiad";
                            break;
                        case "SNACK":
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "Podwieczorek";
                            break;
                        case "SUPPER":
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "Kolacja";
                            break;
                        default:
                            mealsProducts[indexMealProducts].Meals.ElementAt(indexMealTypes).Type = "Typ nieznany";
                            break;
                    }
                    indexMealTypes++;
                }
                indexMealProducts++;
            }
            return mealsProducts;
        }

        public async Task<IEnumerable<DietAnalysisDTO>> GetAllAsync()
        {
            return await appDbContext
               .Diets
               .AsNoTracking()
               .Where(d => d.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
               .OrderBy(d => d.Created)
               .Select(d => new DietAnalysisDTO
               {
                   Created = d.Created.ToString("yyyy:MM:dd HH:mm"),
                   Calories = d.Calories,
                   Meals = d.Meals
               })
               .ToListAsync();
        }

        public async Task<int> Create(DietViewModel model)
        {
            var meals = await appDbContext.Meals.AsNoTracking().Select(m2 => new
            {
                breakfast = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.BREAKFAST).OrderBy(o => Guid.NewGuid()).First(),
                lunch = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.LUNCH).OrderBy(o => Guid.NewGuid()).First(),
                dinner = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.DINNER).OrderBy(o => Guid.NewGuid()).First(),
                snack = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SNACK).OrderBy(o => Guid.NewGuid()).First(),
                supper = appDbContext.Meals.AsNoTracking().Where(m => m.Type == Meal.MealType.SUPPER).OrderBy(o => Guid.NewGuid()).First(),
                ifAlreadyExistDiet = appDbContext.Diets.AsNoTracking().Any(d => d.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
            }).FirstOrDefaultAsync();

            var newDiet = new Diet
            {
                Name = model.Name,
                Calories = model.Calories,
                Meals = model.MealsAmount,
                Created = DateTime.UtcNow,
                DietCurrent = true,
                UserId = httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value
            };

            // Get current diet and set prop DietCurrent to false;
            if (meals.ifAlreadyExistDiet)
            {
                var currentDiet = await appDbContext.Diets
                .Where(d => d.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
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

            return newDiet.Id;
        }

        
    }
}
