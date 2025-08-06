using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumSummerLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class ScoreFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "SCORES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "SCORES");
        }
    }
}
