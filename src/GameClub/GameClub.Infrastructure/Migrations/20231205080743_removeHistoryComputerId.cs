using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameClub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeHistoryComputerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Histories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ComputerId",
                table: "Histories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
