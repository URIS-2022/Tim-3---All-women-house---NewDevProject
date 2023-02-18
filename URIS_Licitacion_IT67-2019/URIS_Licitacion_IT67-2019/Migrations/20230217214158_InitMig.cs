using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_Licitacion_IT67_2019.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licitacions",
                columns: table => new
                {
                    LicitationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfLic = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAnnouncment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineForSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListOfIndividuals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListOfLegalEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    secondRound = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacions", x => x.LicitationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licitacions");
        }
    }
}
