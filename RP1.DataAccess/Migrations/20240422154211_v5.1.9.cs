using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v519 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "FilmName", "ImageName", "Trailer", "ageRating" },
                values: new object[] { 3, "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.", 145, "Oppenheimer", "/Images/Films/168dd146-0c24-4e01-9ad0-91bd8455af24.jpg", "https://www.youtube.com/embed/U2Qp5pL3ovA", 18 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "FilmName", "ImageName", "Trailer", "ageRating" },
                values: new object[] { 2, "During World War II, Lt. Gen. Leslie Groves Jr. appoints physicist J. Robert Oppenheimer to work on the top-secret Manhattan Project. Oppenheimer and a team of scientists spend years developing and designing the atomic bomb. Their work comes to fruition on July 16, 1945, as they witness the world's first nuclear explosion, forever changing the course of history.", 145, "Oppenheimer", "/Images/Films/168dd146-0c24-4e01-9ad0-91bd8455af24.jpg", "https://www.youtube.com/embed/U2Qp5pL3ovA", 18 });
        }
    }
}
