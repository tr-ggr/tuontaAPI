using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tuontaAPI.Migrations
{
    /// <inheritdoc />
    public partial class OTINFUCK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatItems_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatItems_ChatId",
                table: "ChatItems",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatItems");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Birthday", "Course", "Distance", "Email", "Gender", "Hobbies", "ProfileImages", "School", "Username" },
                values: new object[,]
                {
                    { 1, "Hello, I'm John!", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Science", 50, "johndoe@example.com", "Male", "[\"Reading\",\"Swimming\"]", "[\"image1.jpg\",\"image2.jpg\"]", "Example University", "johndoe" },
                    { 2, "Hi, I'm Jane!", new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathematics", 30, "janedoe@example.com", "Female", "[\"Running\",\"Cooking\"]", "[\"image3.jpg\",\"image4.jpg\"]", "Example University", "janedoe" },
                    { 3, "Hey, I'm Alex!", new DateTime(1995, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", 20, "alexsmith@example.com", "Other", "[\"Gaming\",\"Hiking\"]", "[\"image5.jpg\",\"image6.jpg\"]", "Example University", "alexsmith" }
                });
        }
    }
}
