using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optik_Arayüz_UI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExamPaperElementmodelupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ExamPaperElements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ExamPaperElements");
        }
    }
}
