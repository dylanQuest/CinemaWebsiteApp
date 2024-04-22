using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v512 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Cost", "TypeName" },
                values: new object[,]
                {
                    { 1, 9.9900000000000002, "type" },
                    { 2, 4.9900000000000002, "type" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
