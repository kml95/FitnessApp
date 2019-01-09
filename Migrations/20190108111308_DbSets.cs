using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class DbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealDiets_Diets_DietId",
                table: "MealDiets");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiets_Meals_MealId",
                table: "MealDiets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDiets",
                table: "MealDiets");

            migrationBuilder.RenameTable(
                name: "MealDiets",
                newName: "MealDiet");

            migrationBuilder.RenameIndex(
                name: "IX_MealDiets_DietId",
                table: "MealDiet",
                newName: "IX_MealDiet_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDiet",
                table: "MealDiet",
                columns: new[] { "MealId", "DietId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_Diets_DietId",
                table: "MealDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_Meals_MealId",
                table: "MealDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealDiet",
                table: "MealDiet");

            migrationBuilder.RenameTable(
                name: "MealDiet",
                newName: "MealDiets");

            migrationBuilder.RenameIndex(
                name: "IX_MealDiet_DietId",
                table: "MealDiets",
                newName: "IX_MealDiets_DietId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealDiets",
                table: "MealDiets",
                columns: new[] { "MealId", "DietId" });

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
        }
    }
}
