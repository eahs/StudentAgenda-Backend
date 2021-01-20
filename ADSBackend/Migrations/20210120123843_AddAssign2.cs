using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class AddAssign2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddAssignment2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class2 = table.Column<string>(nullable: true),
                    Event2 = table.Column<string>(nullable: true),
                    Difficulty2 = table.Column<string>(nullable: true),
                    Materials2 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    timeNeeded2 = table.Column<double>(nullable: false),
                    dateOfEvent2 = table.Column<DateTime>(nullable: false),
                    dateChoice = table.Column<DateTime>(nullable: true),
                    timeChoice = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddAssignment2", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddAssignment2");
        }
    }
}
