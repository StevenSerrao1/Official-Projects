﻿using MyPortfolioSolution.DTO;
using MyPortfolioSolution.ViewModels;
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

        [StringLength(500)]
        [Url]
        public string ProjectURL { get; set; } = string.Empty;

        public DateTimeOffset DateCreated { get; set; }

        public string GitHubViews { get; set; } = string.Empty;

        public string GitHubRepoName { get; set; } = string.Empty;

        public List<Images>? Images { get; set; }

        public Project()
        {
            DateCreated = DateTimeOffset.UtcNow;
        }

    }

    public static class ProjectExtensions
    {
        /// <summary>
        /// Convert Project entity into UI-ready ProjectViewModel (separation of concern)
        /// </summary>
        /// <param name="project">Project object to be converted (current object)</param>
        /// <returns>ProjectViewModel with formatted fields</returns>
        public static ProjectViewModel ToProjectModel(this Project project)
        {
            return new ProjectViewModel
            {
                Title = project.Title,
                ShortDescription = project.Description.Length > 100
                                    ? project.Description.Substring(0, 100) + "..."
                                    : project.Description,
                FullDescription = project.Description,
                ProjectURL = project.ProjectURL,
                DateCreatedFormatted = project.DateCreated.ToString("dd MMM yyyy"),
                GitHubViews = project.GitHubViews,
                GitHubRepoName = project.GitHubRepoName,
                Images = project.Images?.Select(image => new ImageViewModel
                {
                    ImageUrl = image.ImageUrl,
                    Caption = image.Caption,
                    AdditionalInfo = image.AdditionalInfo,
                    AltText = image.AltText,
                    ProjectId = image.ProjectId
                }).ToList() ?? new List<ImageViewModel>() // Handle null collections
            };
        }

        public static ProjectAddResponse ToProjectAddReponse(this Project project)
        {
            return new ProjectAddResponse
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                ProjectURL = project.ProjectURL,
                DateCreatedFormatted = project.DateCreated.ToString("dd MMM yyyy"),
                GitHubViews = project.GitHubViews,
                GitHubRepoName = project.GitHubRepoName,
                Images = project.Images?.Select(image => new ImageAddResponse
                {
                    ImageId = image.ImageId, // Ensure the ImageId is included
                    ImageUrl = image.ImageUrl,
                    Caption = image.Caption,
                    AdditionalInfo = image.AdditionalInfo,
                    AltText = image.AltText,
                    ProjectId = image.ProjectId // Make sure the ProjectId is included
                }).ToList() ?? new List<ImageAddResponse>() // Handle null collections
            };
        }

    }
}
