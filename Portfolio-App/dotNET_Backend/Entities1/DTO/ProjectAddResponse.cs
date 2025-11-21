using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    // Represents the response sent back to the client after a project is added.
    public class ProjectAddResponse
    {
        // The unique identifier for the project.
        public int ProjectId { get; set; }

        // The title of the project.
        public string Title { get; set; } = string.Empty;

        // A brief description of the project.
        public string Description { get; set; } = string.Empty;

        // The URL for the live project or demo.
        public string ProjectURL { get; set; } = string.Empty;

        // A formatted string representing the date the project was created.
        public string DateCreatedFormatted { get; set; } = string.Empty;

        // The name of the GitHub repository associated with the project.
        public string GitHubRepoName { get; set; } = string.Empty;

        // The number of views the project has on GitHub, as a string.
        public string GitHubViews { get; set; } = string.Empty;

        // A collection of image responses associated with the project.
        public List<ImageAddResponse>? Images { get; set; }
    }
}
