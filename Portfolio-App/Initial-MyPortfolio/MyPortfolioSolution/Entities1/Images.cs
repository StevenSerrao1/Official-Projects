using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace MyPortfolioSolution.Entities1
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(500)]
        [Url]
        public string ImageUrl { get; set; } = string.Empty; // Store image links here

        [StringLength(300)]
        public string Caption { get; set; } = string.Empty;

        [StringLength(600)]
        public string AltText { get; set; } = string.Empty;

        [StringLength(1000)]
        public string AdditionalInfo { get; set; } = string.Empty;

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; } // Foreign key to Project

        public Project? Project { get; set; } // Navigation property
    }
    public static class ImageRequestExtensions
    {
        public static ImageAddResponse ToImageAddResponse(this Images image)
        {
            return new ImageAddResponse()
            {
                ImageId = image.ImageId,
                ImageUrl = image.ImageUrl,
                Caption = image.Caption,
                AltText = image.AltText,
                AdditionalInfo = image.AdditionalInfo,
                ProjectId = image.ProjectId
            };
        }

        public static ImageViewModel ToImageViewModel(this Images image)
        {
            return new ImageViewModel()
            {
                ImageUrl = image.ImageUrl,
                Caption = image.Caption,
                AdditionalInfo = image.AdditionalInfo,
                AltText = image.AltText,
                ProjectId = image.ProjectId
            };
        }

        public static ImageAddRequest ToImageAddRequest(this Images image)
        {
            return new ImageAddRequest()
            {
                ImageUrl = image.ImageUrl,
                Caption = image.Caption,
                AdditionalInfo = image.AdditionalInfo,
                AltText = image.AltText
            };
        }
    }
}
