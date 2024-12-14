using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tuontaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
