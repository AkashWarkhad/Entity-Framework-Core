using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedextradata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK" },
                    { 5, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
