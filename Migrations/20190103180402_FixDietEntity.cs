using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class FixDietEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserId1",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_UserId1",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Diets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Diets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId",
                table: "Diets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_AspNetUsers_UserId",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Diets_UserId",
                table: "Diets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Diets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Diets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserId1",
                table: "Diets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_AspNetUsers_UserId1",
                table: "Diets",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
