using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ViewModels
{
    // ViewModel used to present project data in a format that is suitable for the UI.
    public class ProjectViewModel
    {
        // Title of the project, will always have a value (default is an empty string).
        public string Title { get; set; } = string.Empty;

        // A shortened description of the project, could be null if not provided.
        public string? ShortDescription { get; set; }

        // Full description of the project, could be null if not provided.
        public string? FullDescription { get; set; }

        // URL to the project, always has a value (default is an empty string).
        public string ProjectURL { get; set; } = string.Empty;

        // Formatted date when the project was created (e.g., "dd MMM yyyy").
        // This is used for UI rendering and will always have a value.
        public string DateCreatedFormatted { get; set; } = string.Empty;

        // GitHub views, optional field that may be left null if no views are tracked.
        public string? GitHubViews { get; set; }

        // The name of the GitHub repository related to the project, always has a value (default is an empty string).
        public string GitHubRepoName { get; set; } = string.Empty;

        // List of images associated with the project, always initialized as an empty list by default.
        public List<ImageViewModel> Images { get; set; } = new();
    }
}
