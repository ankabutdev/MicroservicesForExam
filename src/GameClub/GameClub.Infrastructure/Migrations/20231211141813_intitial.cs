using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameClub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    PriceOfHour = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoursCount = table.Column<long>(type: "bigint", nullable: false),
                    ComputerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleOfChanges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleOfChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleOfChanges_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleOfChanges_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1L, "test1", "test1" },
                    { 2L, "test2", "test2" },
                    { 3L, "test3", "test3" }
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Name", "PriceOfHour", "Version" },
                values: new object[,]
                {
                    { 1L, "test1", 10.0, "1.0" },
                    { 2L, "test2", 11.0, "2.0" },
                    { 3L, "test3", 12.0, "3.0" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ComputerId", "EndDate", "HoursCount", "NickName", "StartDate" },
                values: new object[,]
                {
                    { 1L, 2L, new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4013), 1L, "test1", new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4013) },
                    { 2L, 2L, new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4019), 1L, "test1", new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4018) },
                    { 3L, 2L, new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4023), 1L, "test1", new DateTime(2023, 12, 11, 14, 18, 12, 914, DateTimeKind.Utc).AddTicks(4023) }
                });

            migrationBuilder.InsertData(
                table: "ScheduleOfChanges",
                columns: new[] { "Id", "AdminId", "Description", "PlayerId", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1L, 2L, "test1", 1L, 0, 12.0 },
                    { 2L, 2L, "test2", 1L, 0, 12.0 },
                    { 3L, 2L, "test3", 1L, 2, 12.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_Version",
                table: "Computers",
                column: "Version",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ComputerId",
                table: "Players",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleOfChanges_AdminId",
                table: "ScheduleOfChanges",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleOfChanges_PlayerId",
                table: "ScheduleOfChanges",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleOfChanges");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
