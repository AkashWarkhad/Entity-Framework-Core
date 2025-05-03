using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToManyRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 4, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MK Sir" });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamica Premiere League" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swami Nath Premiere" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Premiere League" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachId", "CreatedAt", "CreatedBy", "LeagueId", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 4, 0, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK" },
                    { 1, 0, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team" },
                    { 2, 0, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI Team" },
                    { 3, 0, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KKR Team" },
                    { 5, 0, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
