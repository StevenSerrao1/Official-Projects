using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioSolution.Migrations
{
    /// <inheritdoc />
    public partial class updated_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "GitHubRepoName", "GitHubViews" },
                values: new object[] { "Official-Projects", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "GitHubRepoName", "GitHubViews" },
                values: new object[] { "", "0" });
        }
    }
}
