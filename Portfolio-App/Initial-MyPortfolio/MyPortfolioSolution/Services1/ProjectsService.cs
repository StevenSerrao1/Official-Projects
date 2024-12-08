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

        public async Task<ProjectAddResponse> AddProject(ProjectAddRequest par, List<ImageAddRequest> iar)
        {
            // Create the project from ProjectAddRequest
            Project project = par.ToProject();

            // Fetch GitHub views asynchronously
            project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);

            // Add project to context and save changes to get the ProjectId
            _context.Projects!.Add(project);
            await _context.SaveChangesAsync(); // Save the project to get the ProjectId

            // Now create and link images using the ImageService
            List<Images> images = await _imageService.CreateImagesForProject(iar, project.ProjectId);

            // Link images to the project (Images property should be a list of Images entities)
            project.Images = images;

            // Convert the Images entities to ImageAddResponse DTOs
            List<ImageAddResponse> imageAddResponses = images.Select(image => image.ToImageAddResponse()).ToList();

            // Map Project to ProjectAddResponse, including the image responses
            ProjectAddResponse response = project.ToProjectAddReponse();
            response.Images = imageAddResponses;  // Ensure the ProjectAddResponse class has an Images property for the responses

            // Save the images and the linked project to the context
            await _context.SaveChangesAsync();

            // Return the response
            return response;
        }

        public async Task<List<ProjectViewModel>> LoadProjects()
        {
            List<ProjectViewModel> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectModel())
                .ToListAsync();  // Use ToListAsync() for async operation

            Console.WriteLine(projects[0].ToString());

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

        public Task<bool> DeleteProject()
        {
            throw new NotImplementedException();
        }
    }
}
