using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_ProtectedZone_IT67_2019.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProtectedZones",
                columns: table => new
                {
                    ProtectedZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfZone = table.Column<int>(type: "int", nullable: false),
                    PermittedWorks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectedZones", x => x.ProtectedZoneId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentProtectedZones",
                columns: table => new
                {
                    DocumentProtectedZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfSubmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PermitedWorks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtectedZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProtectedZones", x => x.DocumentProtectedZoneId);
                    table.ForeignKey(
                        name: "FK_DocumentProtectedZones_ProtectedZones_ProtectedZoneId",
                        column: x => x.ProtectedZoneId,
                        principalTable: "ProtectedZones",
                        principalColumn: "ProtectedZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProtectedZones_ProtectedZoneId",
                table: "DocumentProtectedZones",
                column: "ProtectedZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentProtectedZones");

            migrationBuilder.DropTable(
                name: "ProtectedZones");
        }
    }
}
