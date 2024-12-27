using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ProjectAddRequest
    {
        // The title of the project being added.
        public string Title { get; set; } = string.Empty;

        // A brief description of the project.
        public string Description { get; set; } = string.Empty;

        // The URL for the live project or demo.
        public string ProjectURL { get; set; } = string.Empty;

        // The name of the GitHub repository associated with the project.
        public string GitHubRepoName { get; set; } = string.Empty;

        // A collection of image requests to associate images with the project.
        public List<ImageAddRequest> Images { get; set; } = new List<ImageAddRequest>();
    }

    // Extension methods to simplify transformations related to ProjectAddRequest.
    public static class ProjectRequestExtensions
    {
        /// <summary>
        /// Converts a ProjectAddRequest into a Project entity.
        /// </summary>
        /// <param name="par">The ProjectAddRequest object containing input data.</param>
        /// <returns>A Project entity with data mapped from the request.</returns>
        public static Project ToProject(this ProjectAddRequest par)
        {
            // Initialize a list to hold formatted image entities.
            List<Images> FormattedImages = new List<Images>();

            // Iterate through each ImageAddRequest in the request's Images collection.
            foreach (ImageAddRequest img in par.Images)
            {
                // Convert ImageAddRequest to an Images entity and add it to the list.
                FormattedImages.Add(img.ToImages());
            }

            // Return a new Project entity with data from the request and formatted images.
            return new Project
            {
                Title = par.Title, // Map Title property.
                Description = par.Description, // Map Description property.
                ProjectURL = par.ProjectURL, // Map Project URL.
                GitHubRepoName = par.GitHubRepoName, // Map GitHub repository name.
                Images = FormattedImages // Associate formatted images with the project.
            };
        }
    };
}
