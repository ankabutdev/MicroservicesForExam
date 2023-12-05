using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameClub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removecomputerHistoryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Histories_HistoryId",
                table: "Computers");

            migrationBuilder.AlterColumn<long>(
                name: "HistoryId",
                table: "Computers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Histories_HistoryId",
                table: "Computers",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Histories_HistoryId",
                table: "Computers");

            migrationBuilder.AlterColumn<long>(
                name: "HistoryId",
                table: "Computers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Histories_HistoryId",
                table: "Computers",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
