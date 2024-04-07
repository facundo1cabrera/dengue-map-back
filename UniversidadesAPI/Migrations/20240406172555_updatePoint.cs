using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversidadesAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatePoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "GeoPoints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GeoPoints",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
