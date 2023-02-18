using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_BiddingProcess_it24.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biddings",
                columns: table => new
                {
                    BiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BiddingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excepted = table.Column<bool>(type: "bit", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    DateOfMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biddings", x => x.BiddingId);
                });

            migrationBuilder.CreateTable(
                name: "BiddingsConditions",
                columns: table => new
                {
                    BiddingConditionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RentalDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiddingsConditions", x => x.BiddingConditionsId);
                    table.ForeignKey(
                        name: "FK_BiddingsConditions_Biddings_BiddingId",
                        column: x => x.BiddingId,
                        principalTable: "Biddings",
                        principalColumn: "BiddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningsOfBids",
                columns: table => new
                {
                    OpeningOfBidsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArrivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivingHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningsOfBids", x => x.OpeningOfBidsId);
                    table.ForeignKey(
                        name: "FK_OpeningsOfBids_Biddings_BiddingId",
                        column: x => x.BiddingId,
                        principalTable: "Biddings",
                        principalColumn: "BiddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicBiddings",
                columns: table => new
                {
                    PublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceStep = table.Column<int>(type: "int", nullable: false),
                    BiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicBiddings", x => x.PublicBiddingId);
                    table.ForeignKey(
                        name: "FK_PublicBiddings_Biddings_BiddingId",
                        column: x => x.BiddingId,
                        principalTable: "Biddings",
                        principalColumn: "BiddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiddingsConditions_BiddingId",
                table: "BiddingsConditions",
                column: "BiddingId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningsOfBids_BiddingId",
                table: "OpeningsOfBids",
                column: "BiddingId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicBiddings_BiddingId",
                table: "PublicBiddings",
                column: "BiddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiddingsConditions");

            migrationBuilder.DropTable(
                name: "OpeningsOfBids");

            migrationBuilder.DropTable(
                name: "PublicBiddings");

            migrationBuilder.DropTable(
                name: "Biddings");
        }
    }
}
