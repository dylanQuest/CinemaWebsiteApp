using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v514 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Theatres",
                columns: new[] { "Id", "Capacity", "TheatreNum" },
                values: new object[,]
                {
                    { 1, 24, 1 },
                    { 2, 48, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeName",
                value: "Adult");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeName",
                value: "Child");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Theatres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theatres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeName",
                value: "type");

            migrationBuilder.UpdateData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeName",
                value: "type");
        }
    }
}
