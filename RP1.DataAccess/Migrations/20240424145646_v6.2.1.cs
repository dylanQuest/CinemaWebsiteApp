using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v621 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "FilmName", "ImageName", "Trailer", "ageRating" },
                values: new object[,]
                {
                    { 7, "While working on a documentary at sea, an oceanographer's work partner gets killed by a shark. Soon, along with a crew, he sets off on an expedition to exact revenge on the aquatic animal.", 98, "The Life Aquatic", "/Images/Films/aqua.jpg", "https://www.youtube.com/embed/UpU0DZXTGA0", 16 },
                    { 8, "In a post-apocalyptic age, Nausicaa, a princess who guards the Valley of the Wind, tries to stop two warring nations from destroying everything around them.", 117, "Nausicaä ", "/Images/Films/nausicaa.jpg", "https://www.youtube.com/embed/6zhLBe319KE", 12 },
                    { 9, "Biker Kaneda is confronted by many anti-social elements while trying to help his friend Tetsuo who is involved in a secret government project. Tetsuo's supernatural persona adds the final twist.", 124, "Akira", "/Images/Films/akira.jpg", "https://www.youtube.com/embed/nA8KmHC2Z-g", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
