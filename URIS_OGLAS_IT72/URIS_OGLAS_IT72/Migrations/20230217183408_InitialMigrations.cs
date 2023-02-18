using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_OGLAS_IT72.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DecisionOfAdvertisments",
                columns: table => new
                {
                    DecisionOfAdvertismentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VremeDonosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NazivOdluke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionOfAdvertisments", x => x.DecisionOfAdvertismentId);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    AdvertismentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipGaranta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionOfAdvertismentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.AdvertismentId);
                    table.ForeignKey(
                        name: "FK_Advertisments_DecisionOfAdvertisments_DecisionOfAdvertismentId",
                        column: x => x.DecisionOfAdvertismentId,
                        principalTable: "DecisionOfAdvertisments",
                        principalColumn: "DecisionOfAdvertismentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_DecisionOfAdvertismentId",
                table: "Advertisments",
                column: "DecisionOfAdvertismentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "DecisionOfAdvertisments");
        }
    }
}
