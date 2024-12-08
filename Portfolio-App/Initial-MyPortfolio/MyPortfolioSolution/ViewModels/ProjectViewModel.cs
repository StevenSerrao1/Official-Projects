using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ViewModels
{
    public class ProjectViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? FullDescription { get; set; }
        public string ProjectURL { get; set; } = string.Empty;
        public string DateCreatedFormatted { get; set; } = string.Empty;
        public string? GitHubViews { get; set; } 
        public List<ImageViewModel> Images { get; set; } = new();

    }

}
