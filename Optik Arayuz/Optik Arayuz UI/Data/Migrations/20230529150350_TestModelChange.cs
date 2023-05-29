using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optik_Arayüz_UI.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreakPoint",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakPoint",
                table: "Tests");
        }
    }
}
