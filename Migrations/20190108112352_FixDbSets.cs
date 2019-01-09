using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class FixDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTraining_Exercise_ExerciseId",
                table: "ExerciseTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTraining_Training_TrainingId",
                table: "ExerciseTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_Diets_DietId",
                table: "MealDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_Meals_MealId",
                table: "MealDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_AspNetUsers_UserId1",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDiet",
                table: "MealDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseTraining",
                table: "ExerciseTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Training",
                newName: "Trainings");

            migrationBuilder.RenameTable(
                name: "MealDiet",
                newName: "MealDiets");

            migrationBuilder.RenameTable(
                name: "ExerciseTraining",
                newName: "ExerciseTrainings");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Training_UserId1",
                table: "Trainings",
                newName: "IX_Trainings_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_MealDiet_DietId",
                table: "MealDiets",
                newName: "IX_MealDiets_DietId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTraining_TrainingId",
                table: "ExerciseTrainings",
                newName: "IX_ExerciseTrainings_TrainingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainings",
                table: "Trainings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDiets",
                table: "MealDiets",
                columns: new[] { "MealId", "DietId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseTrainings",
                table: "ExerciseTrainings",
                columns: new[] { "ExerciseId", "TrainingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTrainings_Exercises_ExerciseId",
                table: "ExerciseTrainings",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTrainings_Trainings_TrainingId",
                table: "ExerciseTrainings",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiets_Diets_DietId",
                table: "MealDiets",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiets_Meals_MealId",
                table: "MealDiets",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId1",
                table: "Trainings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTrainings_Exercises_ExerciseId",
                table: "ExerciseTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTrainings_Trainings_TrainingId",
                table: "ExerciseTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiets_Diets_DietId",
                table: "MealDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiets_Meals_MealId",
                table: "MealDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId1",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainings",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDiets",
                table: "MealDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseTrainings",
                table: "ExerciseTrainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Trainings",
                newName: "Training");

            migrationBuilder.RenameTable(
                name: "MealDiets",
                newName: "MealDiet");

            migrationBuilder.RenameTable(
                name: "ExerciseTrainings",
                newName: "ExerciseTraining");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_UserId1",
                table: "Training",
                newName: "IX_Training_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_MealDiets_DietId",
                table: "MealDiet",
                newName: "IX_MealDiet_DietId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseTrainings_TrainingId",
                table: "ExerciseTraining",
                newName: "IX_ExerciseTraining_TrainingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDiet",
                table: "MealDiet",
                columns: new[] { "MealId", "DietId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseTraining",
                table: "ExerciseTraining",
                columns: new[] { "ExerciseId", "TrainingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTraining_Exercise_ExerciseId",
                table: "ExerciseTraining",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTraining_Training_TrainingId",
                table: "ExerciseTraining",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiet_Diets_DietId",
                table: "MealDiet",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiet_Meals_MealId",
                table: "MealDiet",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_AspNetUsers_UserId1",
                table: "Training",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
