namespace MyPortfolioSolution.ViewModels
{
    // ViewModel used to present image data related to a project.
    public class ImageViewModel
    {
        // URL of the image, will always have a value (default is an empty string).
        public string ImageUrl { get; set; } = string.Empty;

        // Caption or description of the image, could be null if not provided.
        public string? Caption { get; set; }

        // Alt text for the image, will always have a value (default is an empty string).
        // This is used for accessibility and image SEO.
        public string AltText { get; set; } = string.Empty;

        // Additional information related to the image, could be an optional field.
        public string AdditionalInfo { get; set; } = string.Empty;

        // ProjectId that the image belongs to. This links the image to its project.
        public int ProjectId { get; set; }
    }
}
