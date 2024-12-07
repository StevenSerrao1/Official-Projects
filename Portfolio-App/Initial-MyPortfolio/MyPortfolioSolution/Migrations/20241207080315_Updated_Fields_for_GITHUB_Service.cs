using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioSolution.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Fields_for_GITHUB_Service : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GitHubViews",
                table: "Projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "GitHubRepoName",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://content.swncdn.com/godvine/pics/GV-Article/dogsmiles-1.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "GitHubRepoName", "GitHubViews" },
                values: new object[] { "", "0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubRepoName",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "GitHubViews",
                table: "Projects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://farm4.staticflickr.com/3256/2594247316_85bcbfdeb1_o_d.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "GitHubViews",
                value: 0);
        }
    }
}
