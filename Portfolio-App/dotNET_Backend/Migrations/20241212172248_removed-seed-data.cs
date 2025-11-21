using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioSolution.Migrations
{
    /// <inheritdoc />
    public partial class removedseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DateCreated", "Description", "GitHubRepoName", "GitHubViews", "ProjectURL", "Title" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "My professional portfolio, showcasing my projects with entries ranging from personal projects to commercial projects. All projects use a variety of tech stacks, with a primary focus throughout on ASP.NET Core, which is my specialty.", "Official-Projects", "", "localhost:3000", "Full-Stack Development Portfolio" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "AltText", "Caption", "ImageUrl", "ProjectId" },
                values: new object[] { 1, "smiling dog", "a very, very good boy.", "https://content.swncdn.com/godvine/pics/GV-Article/dogsmiles-1.jpg", 1 });
        }
    }
}
