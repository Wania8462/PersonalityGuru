using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalityGuru.Server.Migrations
{
    /// <inheritdoc />
    public partial class questionsUpdate_01_11_24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Text",
                value: "Я всегда выбираю точные специализации и навыки");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Text",
                value: "Я всегда выбераю точные специализации и навыки");
        }
    }
}
