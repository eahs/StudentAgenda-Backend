using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class AAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(nullable: true),
                    Event = table.Column<string>(nullable: true),
                    Difficulty = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    timeNeeded = table.Column<double>(nullable: false),
                    dateOfEvent = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddAssignment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddAssignment");
        }
    }
}
