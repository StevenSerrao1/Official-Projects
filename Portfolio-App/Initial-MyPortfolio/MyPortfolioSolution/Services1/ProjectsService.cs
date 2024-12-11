using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.Models.Enums;
using MyPortfolioSolution.ViewModels;
using MyPortfolioSolution.ServiceContracts1;
using Microsoft.EntityFrameworkCore;
using MyPortfolioSolution.DTO;

namespace MyPortfolioSolution.Services1
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGitHubService _gitHubService;
        private readonly IImageService _imageService;
        
        public ProjectsService(ApplicationDbContext context, IGitHubService gitHubService, IImageService imageService)
        {
            _context = context;
            _gitHubService = gitHubService;
            _imageService = imageService;
        }

        public async Task<ProjectAddResponse> AddProject(ProjectAddRequest par)
        {
            // Create the project from ProjectAddRequest
            Project project = par.ToProject();

            // Fetch GitHub views asynchronously
            project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);

            // Add project to context and save changes to get the ProjectId
            _context.Projects!.Add(project);
            await _context.SaveChangesAsync();

            // Create and link images using the ImageService
            List<Images> images = await _imageService.CreateImagesForProject(
                project.Images!.Select(image => image.ToImageAddRequest()).ToList(),
                project.ProjectId
            );

            // Link images to the project
            project.Images = images;

            // Convert the Images entities to ImageAddResponse DTOs
            List<ImageAddResponse> imageAddResponses = images.Select(image => image.ToImageAddResponse()).ToList();

            // Map Project to ProjectAddResponse, including the image responses
            ProjectAddResponse response = project.ToProjectAddReponse();
            response.Images = imageAddResponses;

            // Save the images and the linked project to the context
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<List<ProjectViewModel>> LoadProjects()
        {
            List<ProjectViewModel> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectModel())
                .ToListAsync();  // Use ToListAsync() for async operation

            // Iterate through each project and fetch GitHub views asynchronously
            foreach (var project in projects)
            {
                // Call the GitHub service to get the views asynchronously
                project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);
            }

            return projects;
        }

        public async Task<List<ProjectAddResponse>> LoadAdminProjects()
        {
            // Fetch the projects with their images
            List <ProjectAddResponse> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectAddReponse()) // Project is converted to ProjectAddResponse
                .ToListAsync();

            // Iterate through each project and fetch GitHub views asynchronously
            foreach (var project in projects)
            {
                // Call the GitHub service to get the views asynchronously
                project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);
            }

            return projects;
        }

        public Task<List<Project>> GetSortedProjects(Sort sort)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            Project? projectRetrieved = await _context.Projects!
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (projectRetrieved == null)
            {
                // Handle the case where the project doesn't exist
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            return projectRetrieved;
        }

        public async Task<bool> DeleteProject(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            // Retrieve the project directly from the context
            Project? projectToDelete = await GetProjectById(id);

            if (projectToDelete == null)
            {
                // Handle the case where the project doesn't exist
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            // Remove the project from the context
            _context.Projects!.Remove(projectToDelete);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return true if the project was successfully deleted (i.e., no longer in the database)
            return true;
        }
    }
}
