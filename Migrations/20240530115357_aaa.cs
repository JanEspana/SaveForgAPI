using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrogGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_Username",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_Username",
                table: "Scores");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_Username",
                table: "Scores",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_Username",
                table: "Scores",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username");
        }
    }
}
