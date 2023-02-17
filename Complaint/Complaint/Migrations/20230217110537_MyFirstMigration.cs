using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Complaint.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    IdComplaint = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOfComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.IdComplaint);
                });

            migrationBuilder.InsertData(
                table: "Complaint",
                columns: new[] { "IdComplaint", "StatusOfComplaint", "SubmissionDate", "TypeOfComplaint" },
                values: new object[,]
                {
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Not approved", new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complaint against the Decision on Leasing" },
                    { new Guid("6a411c13-a195-48f7-8dbd-67596c3975c0"), "Not approved", new DateTime(2017, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complaint against the Decision on Leasing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");
        }
    }
}
