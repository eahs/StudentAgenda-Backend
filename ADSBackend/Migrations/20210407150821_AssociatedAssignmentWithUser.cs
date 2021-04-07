using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class AssociatedAssignmentWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Assignment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_UserId",
                table: "Assignment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_AspNetUsers_UserId",
                table: "Assignment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_AspNetUsers_UserId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_UserId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assignment");
        }
    }
}
