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

        // Constructor for dependency injection of services
        public ProjectsService(ApplicationDbContext context, IGitHubService gitHubService, IImageService imageService)
        {
            _context = context;
            _gitHubService = gitHubService;
            _imageService = imageService;
        }

        public async Task<ProjectAddResponse> AddProject(ProjectAddRequest par)
        {
            // Create a new project entity from the incoming request DTO
            Project project = par.ToProject();

            // Fetch GitHub views data for the project repository
            project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);

            // Add the new project entity to the DbContext and save it
            _context.Projects!.Add(project);
            await _context.SaveChangesAsync();

            // Create and associate images for the project using the ImageService
            List<Images> images = await _imageService.CreateImagesForProject(
                project.Images!.Select(image => image.ToImageAddRequest()).ToList(),
                project.ProjectId
            );

            // Link the newly created images to the project
            project.Images = images;

            // Map image entities to response DTOs
            List<ImageAddResponse> imageAddResponses = images.Select(image => image.ToImageAddResponse()).ToList();

            // Create a response DTO that includes the project and its images
            ProjectAddResponse response = project.ToProjectAddReponse();
            response.Images = imageAddResponses;

            // Save the updated project and images to the database
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<List<ProjectViewModel>> LoadProjects()
        {
            // Load all projects with their images, and map them to view models
            List<ProjectViewModel> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectModel())
                .ToListAsync();

            // Fetch GitHub views data for each project asynchronously
            foreach (var project in projects)
            {
                project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);
            }

            return projects;
        }

        public async Task<List<ProjectAddResponse>> LoadAdminProjects()
        {
            // Load all projects with their images, and map them to response DTOs
            List<ProjectAddResponse> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectAddReponse())
                .ToListAsync();

            // Fetch GitHub views data for each project asynchronously
            foreach (var project in projects)
            {
                project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);
            }

            return projects;
        }

        public async Task<Project> GetProjectById(int? id)
        {
            if (id == null)
            {
                // Ensure that the project ID is provided
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            // Retrieve the project from the database, including its images
            Project? projectRetrieved = await _context.Projects!
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (projectRetrieved == null)
            {
                // Handle the case where the project doesn't exist
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            // Fetch GitHub views data for the project repository
            projectRetrieved.GitHubViews = _gitHubService.GetGitHubViewsAsync(projectRetrieved.GitHubRepoName).ToString();

            return projectRetrieved;
        }

        public async Task<bool> DeleteProject(int? id)
        {
            if (id == null)
            {
                // Ensure that the project ID is provided
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");
            }

            // Retrieve the project by ID
            Project? projectToDelete = await GetProjectById(id);

            if (projectToDelete == null)
            {
                // Handle the case where the project doesn't exist
                throw new KeyNotFoundException($"Project with ID {id} not found.");
            }

            // Remove the project from the DbContext
            _context.Projects!.Remove(projectToDelete);

            // Save the changes to confirm deletion
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ProjectAddResponse> UpdateProject(ProjectAddResponse? project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));

            // Retrieve the existing project by ID
            Project? existingProject = await GetProjectById(project.ProjectId);

            if (existingProject == null) throw new ArgumentException("ProjectId does not exist");

            // Update the project's properties, excluding the ID
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.ProjectURL = project.ProjectURL;
            existingProject.GitHubRepoName = project.GitHubRepoName;

            // Handle updating the project's images
            if (project.Images.Count != 0)
            {
                existingProject.Images!.Clear(); // Clear existing images
                foreach (var image in project.Images)
                {
                    existingProject.Images.Add(image.ToImage()); // Add new images
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingProject.ToProjectAddReponse();
        }
    }
}
