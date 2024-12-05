﻿using MyPortfolioSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolioSolution.Entities1
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [StringLength(800)]
        public string Description { get; set; } = string.Empty;

        [StringLength(200)]
        [Url]
        public string ProjectURL { get; set; } = string.Empty;

        public DateTimeOffset DateCreated { get; set; }

        public int GitHubViews { get; set; }

        public ICollection<Images>? Images { get; set; }

    }

    public static class ProjectExtensions
    {
        /// <summary>
        /// Convert Project entity into UI-ready ProjectViewModel (separation of concern)
        /// </summary>
        /// <param name="project">Project object to be converted (current object)</param>
        /// <returns>ProjectViewModel with formatted fields</returns>
        public static ViewModels.ProjectViewModel ToProjectModel(this Project project)
        {
            return new ViewModels.ProjectViewModel
            {
                Title = project.Title,
                ShortDescription = project.Description.Length > 100
                                    ? project.Description.Substring(0, 100) + "..."
                                    : project.Description,
                FullDescription = project.Description,
                ProjectURL = project.ProjectURL,
                DateCreatedFormatted = project.DateCreated.ToString("dd MMM yyyy"),
                GitHubViews = project.GitHubViews.ToString(),
                Images = project.Images?.Select(image => new ImageViewModel
                {
                    ImageUrl = image.ImageUrl,
                    Caption = image.Caption,
                    AltText = image.AltText
                }).ToList() ?? new List<ImageViewModel>() // Handle null collections
            };
        }
    }
}
