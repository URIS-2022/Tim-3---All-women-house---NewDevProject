using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_Contract_IT67_2019.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentGuarantor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfSeduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfSigning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
