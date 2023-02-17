using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Land.Migrations.List
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    IdList = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SumSurface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelLand = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.IdList);
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "IdList", "LabelLand", "SumSurface" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "1500m2" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), "500m2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List");
        }
    }
}
