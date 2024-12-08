namespace MyPortfolioSolution.DTO
{
    public class ImageAddResponse
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public int ProjectId { get; set; } // Only include the ID to show the link
    }
}
