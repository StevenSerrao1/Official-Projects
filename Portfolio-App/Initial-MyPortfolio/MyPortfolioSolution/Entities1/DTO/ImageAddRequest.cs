namespace MyPortfolioSolution.DTO
{
    public class ImageAddRequest
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string? Caption { get; set; }
        public string AltText { get; set; } = string.Empty;
    }
}
