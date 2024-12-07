using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ProjectAddResponse
    {
        public int ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ProjectURL { get; set; } = string.Empty;
        public string DateCreatedFormatted { get; set; } = string.Empty;
        public string? GitHubRepoName { get; set; }
        public string GitHubViews { get; set; } = string.Empty;
        public List<Images> Images { get; set; } = new();
    }

}
