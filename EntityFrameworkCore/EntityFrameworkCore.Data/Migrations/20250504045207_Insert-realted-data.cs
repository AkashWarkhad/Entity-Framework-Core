using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Insertrealteddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leagues",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "CreatedAt", "CreatedBy", "Date", "HomeTeamId", "HomeTeamScore", "ModifiedBy", "ModifiedDate", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20, "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { 2, 4, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leagues",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "ModifiedBy", "ModifiedDate" },
                values: new object[] { null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
