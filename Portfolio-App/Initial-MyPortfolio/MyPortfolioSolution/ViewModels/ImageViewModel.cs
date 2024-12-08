namespace MyPortfolioSolution.ViewModels
{
    public class ImageViewModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public string AltText { get; set; } = string.Empty;
        public int ProjectId { get; set; }
    }
}
