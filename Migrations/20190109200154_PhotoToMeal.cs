using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class PhotoToMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Trainings");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Trainings",
                nullable: true);
        }
    }
}
