using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace MyPortfolioSolution.Entities1
{
    // Represents an image associated with a project in the portfolio.
    public class Images
    {
        // Unique identifier for the image.
        [Key]
        public int ImageId { get; set; }

        // URL of the image, limited to 500 characters.
        // This field stores the actual image link.
        [StringLength(500)]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        // Caption for the image, provides a short description or title.
        // This field has a max length of 300 characters.
        [StringLength(300)]
        public string Caption { get; set; } = string.Empty;

        // Alt text for the image, useful for SEO and accessibility.
        [StringLength(600)]
        public string AltText { get; set; } = string.Empty;

        // Additional information about the image, such as credits or context.
        [StringLength(1000)]
        public string AdditionalInfo { get; set; } = string.Empty;

        // Foreign key linking the image to a specific project.
        // This defines a relationship between the image and a project.
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }

        // Navigation property for the related project entity.
        public Project? Project { get; set; }
    }

    // Static class that contains extension methods for converting Images entities into various response models or view models.
    public static class ImageRequestExtensions
    {
        // Converts an Images entity to an ImageAddResponse object.
        // This is typically used for API responses that send image data to the client.
        public static ImageAddResponse ToImageAddResponse(this Images image)
        {
            return new ImageAddResponse()
            {
                ImageId = image.ImageId,           // The unique identifier for the image
                ImageUrl = image.ImageUrl,         // The URL of the image
                Caption = image.Caption,           // The caption describing the image
                AltText = image.AltText,           // Alternative text for the image, used for accessibility
                AdditionalInfo = image.AdditionalInfo, // Any additional information related to the image (e.g., credits, context)
                ProjectId = image.ProjectId        // The foreign key to the related project
            };
        }

        // Converts an Images entity to an ImageViewModel.
        // This is used for displaying image data on the UI, ensuring the entity is represented in a more user-friendly way.
        public static ImageViewModel ToImageViewModel(this Images image)
        {
            return new ImageViewModel()
            {
                ImageUrl = image.ImageUrl,           // The URL of the image
                Caption = image.Caption,             // The caption describing the image
                AdditionalInfo = image.AdditionalInfo, // Any additional information related to the image (e.g., credits, context)
                AltText = image.AltText,             // Alternative text for the image, used for accessibility
                ProjectId = image.ProjectId          // The foreign key to the related project
            };
        }

        // Converts an Images entity to an ImageAddRequest object.
        // This is typically used for API requests when adding new images to a project.
        public static ImageAddRequest ToImageAddRequest(this Images image)
        {
            return new ImageAddRequest()
            {
                ImageUrl = image.ImageUrl,             // The URL of the image
                Caption = image.Caption,               // The caption describing the image
                AdditionalInfo = image.AdditionalInfo, // Any additional information related to the image (e.g., credits, context)
                AltText = image.AltText                // Alternative text for the image, used for accessibility
            };
        }
    }
}
