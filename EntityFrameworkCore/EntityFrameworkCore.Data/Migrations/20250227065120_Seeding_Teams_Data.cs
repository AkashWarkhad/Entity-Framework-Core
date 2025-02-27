using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Teams_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 4, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "MK Sir" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team" },
                    { 2, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI Team" },
                    { 3, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "KKR Team" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
