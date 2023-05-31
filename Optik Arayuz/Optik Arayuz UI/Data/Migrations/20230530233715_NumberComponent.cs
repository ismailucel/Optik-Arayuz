using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optik_Arayüz_UI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NumberComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Columns",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Columns",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Numbers");
        }
    }
}
