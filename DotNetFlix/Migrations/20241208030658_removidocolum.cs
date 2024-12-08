using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetFlix.Migrations
{
    /// <inheritdoc />
    public partial class removidocolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFilm",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Rental");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFilm",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
