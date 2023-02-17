using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Complaint.Migrations.Decision
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decision",
                columns: table => new
                {
                    IdDecision = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MinistryOpinion = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.IdDecision);
                });

            migrationBuilder.InsertData(
                table: "Decision",
                columns: new[] { "IdDecision", "DecisionDate", "MinistryOpinion" },
                values: new object[,]
                {
                    { new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"), new DateTime(2017, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), new DateTime(2017, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Decision");
        }
    }
}
