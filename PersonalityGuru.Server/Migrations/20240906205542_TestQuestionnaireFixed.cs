using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalityGuru.Server.Migrations
{
    /// <inheritdoc />
    public partial class TestQuestionnaireFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                column: "Text",
                value: "Второй вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                column: "Text",
                value: "Третий вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                column: "Text",
                value: "Четвертый вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 105,
                column: "Text",
                value: "Пятый вопрос");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                column: "Text",
                value: "Первый вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                column: "Text",
                value: "Первый вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                column: "Text",
                value: "Первый вопрос");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 105,
                column: "Text",
                value: "Первый вопрос");
        }
    }
}
