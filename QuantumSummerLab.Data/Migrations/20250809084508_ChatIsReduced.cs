using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumSummerLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChatIsReduced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReduced",
                table: "CHATS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReduced",
                table: "CHATS");
        }
    }
}
