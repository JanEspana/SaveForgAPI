using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrogGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class database1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Users_PlayerId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "Scores",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Score_PlayerId",
                table: "Scores",
                newName: "IX_Scores_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_PlayerId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Score",
                newName: "_id");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_PlayerId",
                table: "Score",
                newName: "IX_Score_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Users_PlayerId",
                table: "Score",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
