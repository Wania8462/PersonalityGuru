using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalityGuru.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "OKЭАН" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Group", "InvertedScore", "TestId", "Text" },
                values: new object[,]
                {
                    { 1, "O", false, 1, "q1" },
                    { 2, "O", true, 1, "q2" },
                    { 3, "O", false, 1, "q3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_QuestionnaireId",
                table: "Questions",
                column: "QuestionnaireId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
