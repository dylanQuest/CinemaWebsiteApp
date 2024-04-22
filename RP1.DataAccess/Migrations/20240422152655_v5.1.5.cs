using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v515 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Duration", "FilmName", "ImageName", "Trailer", "ageRating" },
                values: new object[] { 1, "Paul Atreides unites with Chani and the Fremen while seeking revenge against the conspirators who destroyed his family. Facing a choice between the love of his life and the fate of the universe, he must prevent a terrible future only he can foresee.", 122, "Dune 2", "C:\\Users\\L00169531\\Source\\Repos\\team-1-project\\tut1 - Copy - Copy\\wwwroot\\Images\\Films\\168dd146-0c24-4e01-9ad0-91bd8455af24.jpg", "https://www.youtube.com/embed/U2Qp5pL3ovA", 16 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
