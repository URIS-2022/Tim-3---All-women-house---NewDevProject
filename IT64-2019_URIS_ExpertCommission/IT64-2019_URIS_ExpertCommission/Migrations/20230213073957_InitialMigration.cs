using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT64_2019_URIS_ExpertCommission.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpertCommissions",
                columns: table => new
                {
                    ExpertCommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpertCommissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresidentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfMembers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertCommissions", x => x.ExpertCommissionId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertCommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_ExpertCommissions_ExpertCommissionId",
                        column: x => x.ExpertCommissionId,
                        principalTable: "ExpertCommissions",
                        principalColumn: "ExpertCommissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ExpertCommissionId",
                table: "Members",
                column: "ExpertCommissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ExpertCommissions");
        }
    }
}
