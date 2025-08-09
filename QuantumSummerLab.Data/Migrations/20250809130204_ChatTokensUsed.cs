using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumSummerLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChatTokensUsed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokensUsed",
                table: "CHATS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokensUsed",
                table: "CHATS");
        }
    }
}
