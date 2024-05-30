using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrogGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_PlayerUsername",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerUsername",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "PlayerUsername",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_Username",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_Username",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
                name: "PlayerUsername",
                table: "Scores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerUsername",
                table: "Scores",
                column: "PlayerUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_PlayerUsername",
                table: "Scores",
                column: "PlayerUsername",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
