using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Stage = table.Column<int>(nullable: false),
                    Muscle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    TrainingCurrent = table.Column<bool>(nullable: false),
                    Aim = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTraining",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTraining", x => new { x.ExerciseId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_ExerciseTraining_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTraining_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Muscle", "Name", "Stage" },
                values: new object[,]
                {
                    { 1, 0, "Wyciskanie sztangi leżąc na ławce poziomej", 1 },
                    { 24, 2, "Wspięcia na palce stojąc", 3 },
                    { 25, 4, "Uginanie ramion ze sztangą stojąc podchwytem", 1 },
                    { 26, 4, "Uginanie ramion ze sztangielkami stojąc (uchwyt młotkowy)", 2 },
                    { 27, 4, "Uginanie ramienia ze sztangielką w siadzie (podpora o kolano)", 3 },
                    { 28, 4, "Uginanie ramion ze sztangą łamaną, stojąc", 1 },
                    { 29, 4, "Uginanie ramienia ze sztangielką na modlitewniku", 2 },
                    { 30, 4, "Uginanie ramion ze sztangą nachwytem stojąc", 3 },
                    { 31, 5, "Prostowanie ramion na wyciągu stojąc", 1 },
                    { 32, 5, "Wyciskanie leżąc na ławce poziomej wąskim uchwytem", 2 },
                    { 33, 5, "Wyciskanie francuskie jednorącz sztangielki w siadzie", 3 },
                    { 34, 5, "Wyciskanie francuskie sztangi leżąc", 1 },
                    { 35, 5, "Pompki na poręczach", 2 },
                    { 36, 5, "Prostowanie ramienia ze sztangielką w opadzie tułowia", 3 },
                    { 37, 6, "Unoszenie nóg w zwisie na drążku", 1 },
                    { 38, 6, "Brzuszki", 2 },
                    { 39, 6, "Skłony boczne ze sztangielkami", 3 },
                    { 40, 6, "Przyciąganie kolan do klatki w zwisie na drążku", 1 },
                    { 23, 2, "Prostowanie nóg w siadzie", 2 },
                    { 22, 2, "Przysiady ze sztangą trzymaną z przodu", 1 },
                    { 21, 2, "Odwodzenie nóg na zewnątrz", 3 },
                    { 20, 2, "Przysiady wykroczne ze sztangielkami", 2 },
                    { 2, 0, "Wyciskanie sztangielek leżąc na ławce poziomej", 2 },
                    { 3, 0, "Rozpiętki ze sztangielkami leżąc na ławce skośnej (głową do góry)", 3 },
                    { 4, 0, "Wyciskanie sztangi leżąc na ławce skośnej (głową w górę)", 1 },
                    { 5, 0, "Krzyżowanie linek wyciągu w staniu", 2 },
                    { 6, 0, "Rozpiętki w siadzie na maszynie", 3 },
                    { 7, 1, "Podciąganie na drążku szerokim uchwytem (nachwyt)", 1 },
                    { 8, 1, "Podciąganie sztangi w opadzie (wiosłowanie)", 2 },
                    { 9, 1, "Przyciąganie linki wyciągu dolnego w siadzie płaskim", 3 },
                    { 41, 6, "Skłony tułowia na ławce skośnej", 2 },
                    { 10, 1, "Martwy ciąg", 1 },
                    { 12, 1, "Podciąganie sztangielek w opadzie (wiosłowanie)", 3 },
                    { 13, 3, "Wyciskanie sztangi sprzed głowy", 1 },
                    { 14, 3, "Unoszenie sztangielek bokiem w górę", 2 },
                    { 15, 3, "Unoszenie sztangielek w opadzie tułowia", 3 },
                    { 16, 3, "Wyciskanie sztangielek siedząc", 1 },
                    { 17, 3, "Podciąganie sztangi wzdłuż tułowia", 2 },
                    { 18, 3, "Podciąganie sztangielek wzdłuż tułowia w opadzie", 3 },
                    { 19, 2, "Przysiady ze sztangą na barkach", 1 },
                    { 11, 1, "Ściąganie drążka wyciągu górnego w siadzie podchwytem", 2 },
                    { 42, 6, "Unoszenie nóg leżąc na podłodze", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTraining_TrainingId",
                table: "ExerciseTraining",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_UserId1",
                table: "Training",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTraining");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
