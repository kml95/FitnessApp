using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Helpers;
using FitnessApp.Models.Entities;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.DAL.DTO.TrainingDTO;

namespace FitnessApp.DAL.Repositories
{
    public class TrainingRepository: ITrainingRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TrainingRepository(ApplicationDbContext appContext, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appContext;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Create(TrainingViewModel model)
        {
            var exercises = await appDbContext.Exercises.AsNoTracking().Select(e => new
            {
                chest = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.CHEST)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                back = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.BACK)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                legs = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.LEGS)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                shoulders = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.SHOULDERS)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                triceps = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.TRICEPS)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                biceps = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.BICEPS)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                abs = appDbContext.Exercises.AsNoTracking()
                .Where(e2 => e2.Muscle == Muscle.ABS)
                .GroupBy(e2 => e2.Stage)
                .Select(g => new
                {
                    Exercises = g.ToList()
                })
                .Select(x => x.Exercises.OrderBy(o => Guid.NewGuid()).FirstOrDefault())
                .ToList(),

                ifAlreadyExistTraining = appDbContext.Trainings.AsNoTracking().Any(t => t.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
            }).FirstOrDefaultAsync();

            //// Get current training and set prop TrainingCurrent to false;
            if (exercises.ifAlreadyExistTraining)
            {
                var currentTraining = await appDbContext.Trainings
                .Where(t => t.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .OrderByDescending(t => t.Created).FirstOrDefaultAsync();

                currentTraining.TrainingCurrent = false;
            }

            var newTraining = new Training
            {
                Name = model.Name,
                Days = model.Days,
                Created = DateTime.UtcNow,
                TrainingCurrent = true,
                Aim = model.Aim,
                UserId = httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value
            };

            appDbContext.Trainings.Add(newTraining);
            await appDbContext.SaveChangesAsync();

            //// Create exercise to training
            foreach (var chest in exercises.chest)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = chest.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var back in exercises.back)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = back.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var leg in exercises.legs)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = leg.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var shoulder in exercises.shoulders)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = shoulder.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var biceps in exercises.biceps)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = biceps.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var triceps in exercises.triceps)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = triceps.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }

            foreach (var abs in exercises.abs)
            {
                var exerciseTraining = new ExerciseTraining
                {
                    ExerciseId = abs.Id,
                    TrainingId = newTraining.Id
                };
                appDbContext.ExerciseTrainings.Add(exerciseTraining);
            }
            
            await appDbContext.SaveChangesAsync();

            return newTraining.Id;
        }

        public async Task<TrainingDTO> Get()
        {
            var training = await appDbContext.Trainings.AsNoTracking()
                .Where(t => t.TrainingCurrent && t.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .Select(t => new TrainingDTO
                {
                    Name = t.Name,
                    Days = t.Days,
                    Created = t.Created.ToString("yyyy:MM:dd HH:mm"),
                    Aim = t.Aim,
                    UserName = t.User.FirstName,
                    Exercises = t.ExerciseTrainings
                    .Select(et => et.Exercise)
                    .Select(e => new TrainingDTO.ExerciseDTO
                    {
                        Name = e.Name,
                        Stage = e.Stage,
                        Muscle = e.Muscle,
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return training;
        }

        public async Task<IEnumerable<TrainingDTO>> GetLastAsync(int count)
        {
            var trainings = await appDbContext.Trainings.AsNoTracking()
                .Where(t => !t.TrainingCurrent && t.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
                .OrderByDescending(t => t.Created)
                .Take(count)
                .Select(t => new TrainingDTO
                {
                    Name = t.Name,
                    Days = t.Days,
                    Created = t.Created.ToString("yyyy:MM:dd HH:mm"),
                    Aim = t.Aim,
                    UserName = t.User.FirstName,
                    Exercises = t.ExerciseTrainings
                    .Select(et => et.Exercise)
                    .Select(e => new TrainingDTO.ExerciseDTO
                    {
                        Name = e.Name,
                        Stage = e.Stage,
                        Muscle = e.Muscle,
                    }).ToList()
                })
                .ToListAsync();

            return trainings;
        }

        public async Task<IEnumerable<TrainingAnalysisDTO>> GetAllAsync()
        {
            return await appDbContext
               .Trainings
               .AsNoTracking()
               .Where(t => t.UserId.Equals(httpContextAccessor.HttpContext.User.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value))
               .OrderBy(t => t.Created)
               .Select(t => new TrainingAnalysisDTO
               {
                   Created = t.Created.ToString("yyyy:MM:dd HH:mm"),
                   Days = t.Days
               })
               .ToListAsync();
        }
    }
}
