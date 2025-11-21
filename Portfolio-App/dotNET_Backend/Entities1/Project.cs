using MyPortfolioSolution.DTO;
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
        // Primary Key for the Project entity
        [Key]
        public int ProjectId { get; set; }

        // Title of the project, it must be a string with a maximum length of 100 characters and is required
        [StringLength(100)]
        [Required]
        public string Title { get; set; } = string.Empty;

        // Description of the project with a maximum length of 800 characters
        [StringLength(800)]
        public string Description { get; set; } = string.Empty;

        // URL for the project, should be a valid URL with a maximum length of 500 characters
        [StringLength(500)]
        [Url]
        public string ProjectURL { get; set; } = string.Empty;

        // Date and time when the project was created (using DateTimeOffset for time zone information)
        public DateTimeOffset DateCreated { get; set; }

        // String to store GitHub views (could be for analytics, etc.)
        public string GitHubViews { get; set; } = string.Empty;

        // GitHub repository name for the project
        public string GitHubRepoName { get; set; } = string.Empty;

        // List of images associated with the project (navigation property)
        public List<Images>? Images { get; set; }

        // Constructor to set the creation date to the current UTC time
        public Project()
        {
            DateCreated = DateTimeOffset.UtcNow;
        }
    }

    // Extension methods for the Project entity to map it to view models and DTOs
    public static class ProjectExtensions
    {
        /// <summary>
        /// Converts a Project entity into a ProjectViewModel that is more suitable for UI rendering.
        /// This ensures a separation of concerns between the data model and the view.
        /// </summary>
        /// <param name="project">The Project object to be converted.</param>
        /// <returns>A ProjectViewModel with the necessary fields formatted for the UI.</returns>
        public static ProjectViewModel ToProjectModel(this Project project)
        {
            // Create and return a ProjectViewModel with formatted fields
            return new ProjectViewModel
            {
                Title = project.Title,
                // Short description truncates to 100 characters, appending '...' if necessary
                ShortDescription = project.Description.Length > 100
                                    ? project.Description.Substring(0, 100) + "..."
                                    : project.Description,
                FullDescription = project.Description,  // Full description is kept as is
                ProjectURL = project.ProjectURL,
                // Date formatted as 'dd MMM yyyy'
                DateCreatedFormatted = project.DateCreated.ToString("dd MMM yyyy"),
                GitHubViews = project.GitHubViews,
                GitHubRepoName = project.GitHubRepoName,
                // Map Images list to ImageViewModel list
                Images = project.Images?.Select(image => new ImageViewModel
                {
                    ImageUrl = image.ImageUrl,
                    Caption = image.Caption,
                    AdditionalInfo = image.AdditionalInfo,
                    AltText = image.AltText,
                    ProjectId = image.ProjectId
                }).ToList() ?? new List<ImageViewModel>() // If Images is null, return an empty list
            };
        }

        /// <summary>
        /// Converts a Project entity into a ProjectAddResponse, which is used for API responses or form submissions.
        /// </summary>
        /// <param name="project">The Project object to be converted.</param>
        /// <returns>A ProjectAddResponse DTO with the necessary fields for project creation or updating.</returns>
        public static ProjectAddResponse ToProjectAddReponse(this Project project)
        {
            // Create and return a ProjectAddResponse with necessary fields
            return new ProjectAddResponse
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                ProjectURL = project.ProjectURL,
                // Date formatted as 'dd MMM yyyy'
                DateCreatedFormatted = project.DateCreated.ToString("dd MMM yyyy"),
                GitHubViews = project.GitHubViews,
                GitHubRepoName = project.GitHubRepoName,
                // Map Images list to ImageAddResponse list
                Images = project.Images?.Select(image => new ImageAddResponse
                {
                    ImageId = image.ImageId, // Ensure ImageId is included in the response
                    ImageUrl = image.ImageUrl,
                    Caption = image.Caption,
                    AdditionalInfo = image.AdditionalInfo,
                    AltText = image.AltText,
                    ProjectId = image.ProjectId // Include the ProjectId for image association
                }).ToList() ?? new List<ImageAddResponse>() // If Images is null, return an empty list
            };
        }
    }
}
