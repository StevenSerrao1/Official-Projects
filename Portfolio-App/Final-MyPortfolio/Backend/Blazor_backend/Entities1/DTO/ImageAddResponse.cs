using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ImageAddResponse
    {
        // Unique identifier for the image
        public int ImageId { get; set; }

        // URL where the image is hosted or stored
        public string ImageUrl { get; set; } = string.Empty;

        // A short description or title for the image
        public string Caption { get; set; } = string.Empty;

        // Any additional information about the image
        public string AdditionalInfo { get; set; } = string.Empty;

        // Alternative text for accessibility or fallback when the image cannot be displayed
        public string AltText { get; set; } = string.Empty;

        // The ID of the associated project for linking purposes
        public int ProjectId { get; set; }
    }

    public static class ImageExtensions
    {
        /// <summary>
        /// Converts an ImageAddResponse object to an Images entity.
        /// This ensures compatibility when working with the database layer.
        /// </summary>
        /// <param name="image">The ImageAddResponse object to be converted.</param>
        /// <returns>An Images object containing the same data as the input.</returns>
        public static Images ToImage(this ImageAddResponse image)
        {
            return new Images()
            {
                ImageId = image.ImageId, // Map the ID
                ImageUrl = image.ImageUrl, // Map the URL
                Caption = image.Caption, // Map the caption
                AltText = image.AltText, // Map the alt text for accessibility
                AdditionalInfo = image.AdditionalInfo, // Map any additional info
                ProjectId = image.ProjectId // Maintain the association with the project
            };
        }
    }
}
