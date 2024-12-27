using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ImageAddRequest
    {
        // URL where the image is stored or hosted
        public string ImageUrl { get; set; } = string.Empty;

        // Caption or title for the image, typically displayed as a label or description
        public string Caption { get; set; } = string.Empty;

        // Additional information about the image, such as context or source
        public string AdditionalInfo { get; set; } = string.Empty;

        // Alternative text for the image, used for accessibility or in case the image cannot be displayed
        public string AltText { get; set; } = string.Empty;
    }

    public static class ImageRequestExtensions
    {
        /// <summary>
        /// Converts an ImageAddRequest object into an Images entity.
        /// This allows for the transformation of the request data into an entity suitable for database storage.
        /// </summary>
        /// <param name="request">The ImageAddRequest object to be converted.</param>
        /// <returns>An Images entity with the corresponding data from the ImageAddRequest.</returns>
        public static Images ToImages(this ImageAddRequest request)
        {
            return new Images
            {
                // Mapping the request properties to the entity properties
                ImageUrl = request.ImageUrl, // Store the image URL
                AdditionalInfo = request.AdditionalInfo, // Store any additional image-related information
                Caption = request.Caption, // Store the caption/label for the image
                AltText = request.AltText // Store the alternative text for accessibility
            };
        }
    }
}
