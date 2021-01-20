using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class AddedMemberAssignmentList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Member_MemberId",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_MemberId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Assignment");

            migrationBuilder.CreateTable(
                name: "MemberAssignment",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAssignment", x => new { x.MemberId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_MemberAssignment_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberAssignment_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberAssignment_AssignmentId",
                table: "MemberAssignment",
                column: "AssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberAssignment");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Assignment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_MemberId",
                table: "Assignment",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Member_MemberId",
                table: "Assignment",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
