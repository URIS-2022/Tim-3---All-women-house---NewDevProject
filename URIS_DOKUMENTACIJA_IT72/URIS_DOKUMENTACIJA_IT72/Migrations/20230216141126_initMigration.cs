using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_DOKUMENTACIJA_IT72.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentationLists",
                columns: table => new
                {
                    DocumentationListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentationLists", x => x.DocumentationListId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentationListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentationLists_DocumentationListId",
                        column: x => x.DocumentationListId,
                        principalTable: "DocumentationLists",
                        principalColumn: "DocumentationListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiddingPrograms",
                columns: table => new
                {
                    BiddingProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoundNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiddingPrograms", x => x.BiddingProgramId);
                    table.ForeignKey(
                        name: "FK_BiddingPrograms_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    DecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfDecision = table.Column<int>(type: "int", nullable: false),
                    ParliamentaryDecision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_Decisions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiddingPrograms_DocumentId",
                table: "BiddingPrograms",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_DocumentId",
                table: "Decisions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentationListId",
                table: "Documents",
                column: "DocumentationListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiddingPrograms");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentationLists");
        }
    }
}
