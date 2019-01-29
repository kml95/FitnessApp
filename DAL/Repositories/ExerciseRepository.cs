using FitnessApp.DAL.DTO;
using FitnessApp.DAL.Repositories.Abstracts;
using FitnessApp.Data;
using FitnessApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public ExerciseRepository(ApplicationDbContext appContext)
        {
            this.appDbContext = appContext;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAsync()
        {
            return await appDbContext
                .Exercises
                .AsNoTracking()
                .Select(e => new ExerciseDTO
                {
                    Name = e.Name,
                    Stage = e.Stage,
                    Muscle = e.Muscle
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAsync(int skip, int take)
        {
            return await appDbContext
                .Exercises
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .Select(e => new ExerciseDTO
                {
                    Name = e.Name,
                    Stage = e.Stage,
                    Muscle = e.Muscle
                })
                .ToListAsync();
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            return await appDbContext
                .Exercises
                .AsNoTracking()
                .Where(e => e.Name.Equals(name))
                .Select(e => e.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync()
        {
            return await appDbContext
                .Exercises
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<Exercise> CreateAsync(ExerciseDTO exercise)
        {
            var newExercise = new Exercise
            {
                Name = exercise.Name,
                Stage = exercise.Stage,
                Muscle = exercise.Muscle
            };
            
            appDbContext.Exercises.Add(newExercise);
            await appDbContext.SaveChangesAsync();

            return newExercise;
        }

        public async Task<bool> UpdateAsync(int id, ExerciseDTO exercise)
        {
            var exerciseToUpdate = await appDbContext.Exercises.FindAsync(id);

            if (exerciseToUpdate == null) return false;

            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.Stage = exercise.Stage;
            exerciseToUpdate.Muscle = exercise.Muscle;

            appDbContext.Entry(exerciseToUpdate).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Exercise> DeleteAsync(int id)
        {
            var exercise = await appDbContext.Exercises.FindAsync(id);

            if (exercise == null) return null;

            appDbContext.Exercises.Remove(exercise);
            await appDbContext.SaveChangesAsync();

            return exercise;
        }
    }
}
