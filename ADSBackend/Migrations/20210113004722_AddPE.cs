using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class AddPE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "AddPersonalEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNameOfEvent = table.Column<string>(nullable: true),
                    dateOfEvent = table.Column<DateTime>(nullable: false),
                    PDateOfEvent = table.Column<DateTime>(nullable: true),
                    PTimeNeeded = table.Column<int>(nullable: false),
                    Pdescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddPersonalEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddPersonalEvent");

           
        }
    }
}
