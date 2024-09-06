using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalityGuru.Server.Migrations
{
    /// <inheritdoc />
    public partial class TestQuestionnaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "TestQuestionnaire" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Group", "InvertedScore", "TestId", "Text" },
                values: new object[,]
                {
                    { 101, "O", false, 2, "Первый вопрос" },
                    { 102, "К", false, 2, "Первый вопрос" },
                    { 103, "Э", false, 2, "Первый вопрос" },
                    { 104, "А", false, 2, "Первый вопрос" },
                    { 105, "Н", false, 2, "Первый вопрос" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
