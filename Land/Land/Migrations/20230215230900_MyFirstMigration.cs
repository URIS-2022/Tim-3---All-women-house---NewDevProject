using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Land.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    LabelLand = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoilCulture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormOfProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drainage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.LabelLand);
                });

            migrationBuilder.InsertData(
                table: "Land",
                columns: new[] { "LabelLand", "Drainage", "FormOfProperty", "SoilCulture", "Surface", "Workability", "_Class" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), "possible", "personal", "field", "500m2", "arable", "first" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "possible", "personal", "field", "500m2", "arable", "first" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
