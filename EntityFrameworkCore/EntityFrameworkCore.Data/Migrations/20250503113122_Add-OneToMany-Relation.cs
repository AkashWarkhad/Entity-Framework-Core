using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
                    { 1, 0, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team" },
                    { 2, 0, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI Team" },
                    { 3, 0, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KKR Team" },
                    { 4, 0, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK" },
                    { 5, 0, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team B" }
                });
        }
    }
}
