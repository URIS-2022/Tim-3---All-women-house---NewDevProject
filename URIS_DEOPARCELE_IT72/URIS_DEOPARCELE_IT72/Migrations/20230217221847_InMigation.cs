using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URIS_DEOPARCELE_IT72.Migrations
{
    public partial class InMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartOfParcels",
                columns: table => new
                {
                    PartOfParcelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KvalitetZemljiste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PovrsinaDelaParcele = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfParcels", x => x.PartOfParcelID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartOfParcels");
        }
    }
}
