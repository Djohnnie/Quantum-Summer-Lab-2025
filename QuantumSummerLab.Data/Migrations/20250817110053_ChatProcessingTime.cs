using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumSummerLab.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChatProcessingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessingTime",
                table: "CHATS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessingTime",
                table: "CHATS");
        }
    }
}
