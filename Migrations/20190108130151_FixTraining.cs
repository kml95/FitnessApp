using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class FixTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId1",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_UserId1",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Trainings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Trainings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId",
                table: "Trainings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_UserId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Trainings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Trainings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_UserId1",
                table: "Trainings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_UserId1",
                table: "Trainings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
