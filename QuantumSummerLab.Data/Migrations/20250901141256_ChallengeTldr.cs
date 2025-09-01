using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumSummerLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChallengeTldr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tldr",
                table: "CHALLENGES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tldr",
                table: "CHALLENGES");
        }
    }
}
