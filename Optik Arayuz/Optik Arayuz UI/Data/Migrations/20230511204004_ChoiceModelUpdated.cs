using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optik_Arayüz_UI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChoiceModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Choices_ChoiceId1",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_ChoiceId1",
                table: "Choices");

            migrationBuilder.DropColumn(
                name: "ChoiceId1",
                table: "Choices");

            migrationBuilder.AddColumn<string>(
                name: "Choices",
                table: "Choices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Choices",
                table: "Choices");

            migrationBuilder.AddColumn<int>(
                name: "ChoiceId1",
                table: "Choices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ChoiceId1",
                table: "Choices",
                column: "ChoiceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Choices_ChoiceId1",
                table: "Choices",
                column: "ChoiceId1",
                principalTable: "Choices",
                principalColumn: "ChoiceId");
        }
    }
}
