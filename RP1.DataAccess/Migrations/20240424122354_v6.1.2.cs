using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v612 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 165);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "Trailer" },
                values: new object[] { 180, "https://www.youtube.com/embed/uYPbbksJxIg" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "FilmName", "ImageName", "Trailer", "ageRating" },
                values: new object[,]
                {
                    { 3, "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", 113, "Barbie", "/Images/Films/barbie.jpg", "https://www.youtube.com/embed/pBk4NYhWNMM", 12 },
                    { 4, "Yuta Okkotsu is haunted by the spirit of his childhood friend Rika, who died in a traffic accident. Her spirit no longer appears as the sweet girl he called his beloved. Instead, her spirit has been cursed and she manifests as a monstrous entity who protects him against his will.", 145, "Jujutsu Kaisen", "/Images/Films/jjk.jpg", "https://www.youtube.com/embed/2docezZl574", 16 },
                    { 5, "After a job gone wrong, hitman Ray and his partner await orders from their ruthless boss in Bruges, Belgium, the last place in the world Ray wants to be.", 107, "In Bruges", "/Images/Films/inbrug.png", "https://www.youtube.com/embed/96harmMOyiY", 18 },
                    { 6, "When the passengers and crew of a jet are incapacitated due to food poisoning, a rogue pilot with a drinking problem must cooperate with his ex-girlfriend turned stewardess to bring the plane to a safe landing.", 98, "Airplane", "/Images/Films/airplane.png", "https://www.youtube.com/embed/07pPmCfKi3U", 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "Trailer" },
                values: new object[] { 145, "https://www.youtube.com/embed/U2Qp5pL3ovA" });
        }
    }
}
