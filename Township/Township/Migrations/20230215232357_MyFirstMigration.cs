using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Township.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Township",
                columns: table => new
                {
                    IdTownship = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfTownship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Township", x => x.IdTownship);
                });

            migrationBuilder.InsertData(
                table: "Township",
                columns: new[] { "IdTownship", "NameOfTownship" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), "New town" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Old town" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Township");
        }
    }
}
