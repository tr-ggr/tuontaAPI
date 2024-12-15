using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tuontaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedisChattedonmyMatchedItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isChatted",
                table: "MatchedItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isChatted",
                table: "MatchedItems");
        }
    }
}
