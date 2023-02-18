using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT64_2019_URIS_CustomerRegistration.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealizedArea = table.Column<int>(type: "int", nullable: false),
                    AuthorizedPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payments = table.Column<double>(type: "float", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Guarantor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersons",
                columns: table => new
                {
                    LegalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumLP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    StreetLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Positions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumLP = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersons", x => x.LegalPersonId);
                    table.ForeignKey(
                        name: "FK_LegalPersons_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersons",
                columns: table => new
                {
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    StreetNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumNP = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersons", x => x.NaturalPersonId);
                    table.ForeignKey(
                        name: "FK_NaturalPersons_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_CustomerId",
                table: "LegalPersons",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersons_CustomerId",
                table: "NaturalPersons",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalPersons");

            migrationBuilder.DropTable(
                name: "NaturalPersons");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
