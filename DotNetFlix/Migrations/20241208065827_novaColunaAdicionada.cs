using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetFlix.Migrations
{
    /// <inheritdoc />
    public partial class novaColunaAdicionada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "note",
                table: "Rental",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "note",
                table: "Rental");
        }
    }
}
