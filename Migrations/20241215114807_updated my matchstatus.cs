using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tuontaAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedmymatchstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isChatted",
                table: "MatchedItems",
                newName: "isActive");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "MatchStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "MatchStatuses");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "MatchedItems",
                newName: "isChatted");
        }
    }
}
