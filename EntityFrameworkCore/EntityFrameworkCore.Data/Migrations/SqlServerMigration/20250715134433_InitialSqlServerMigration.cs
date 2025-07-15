using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCore.Data.Migrations.SqlServerMigration
{
    /// <inheritdoc />
    public partial class InitialSqlServerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsHistory_Coaches2_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsHistory_Leagues2_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues2",
                        principalColumn: "Id");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TeamsHistoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Matches2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches2_TeamsHistory_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "TeamsHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches2_TeamsHistory_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "TeamsHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coaches2",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MK Sir" },
                    { 2, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dhoni Sir" },
                    { 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Bond Sir" },
                    { 4, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Sir" },
                    { 5, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ravishari Sir" },
                    { 6, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brusli Sir" }
                });

            migrationBuilder.InsertData(
                table: "Leagues2",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamica Premiere League" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swami Nath Premiere" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indian Premiere League" }
                });

            migrationBuilder.InsertData(
                table: "TeamsHistory",
                columns: new[] { "Id", "CoachId", "CreatedAt", "CreatedBy", "LeagueId", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", 1, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team" },
                    { 2, 2, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", 2, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI Team" },
                    { 3, 3, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", 3, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "KKR Team" },
                    { 4, 4, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", null, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK" },
                    { 5, 5, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", 2, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSK Team B" }
                });

            migrationBuilder.InsertData(
                table: "Matches2",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "CreatedAt", "CreatedBy", "Date", "HomeTeamId", "HomeTeamScore", "ModifiedBy", "ModifiedDate", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { 2, 4, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akash Warkhad", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, "Akash Warkhad", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches2_AwayTeamId",
                table: "Matches2",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches2_HomeTeamId",
                table: "Matches2",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsHistory_CoachId",
                table: "TeamsHistory",
                column: "CoachId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamsHistory_LeagueId",
                table: "TeamsHistory",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsHistory_Name",
                table: "TeamsHistory",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches2");

            migrationBuilder.DropTable(
                name: "TeamsHistory")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TeamsHistoryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Coaches2");

            migrationBuilder.DropTable(
                name: "Leagues2");
        }
    }
}
