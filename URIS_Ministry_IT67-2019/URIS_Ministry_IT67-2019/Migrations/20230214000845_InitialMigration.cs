using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_Ministry_IT67_2019.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ministries",
                columns: table => new
                {
                    MinistryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinistryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minister = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.MinistryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ministries");
        }
    }
}
