using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v517 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "/Images/Films/168dd146-0c24-4e01-9ad0-91bd8455af24.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "..\\..\\..\\wwwroot\\Images\\Films\\168dd146-0c24-4e01-9ad0-91bd8455af24.jpg");
        }
    }
}
