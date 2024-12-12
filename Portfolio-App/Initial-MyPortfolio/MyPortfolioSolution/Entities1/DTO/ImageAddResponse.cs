using MyPortfolioSolution.Entities1;

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

    public static class ImageExtensions
    {
        public static Images ToImage(this ImageAddResponse image)
        {
            return new Images()
            {
                ImageId = image.ImageId,
                ImageUrl = image.ImageUrl,
                Caption = image.Caption,
                AltText = image.AltText,
                ProjectId = image.ProjectId
            };
        }
    }
}
