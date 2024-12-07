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

        public async Task<ProjectAddResponse> AddProject(ProjectAddRequest par, string imageUrls, string captions, string alttexts)
        {
            // Create the project
            Project project = par.ToProject();

            project.GitHubViews = await _gitHubService.GetGitHubViewsAsync(project.GitHubRepoName);

            // Add project to context and save changes to get the ProjectId
            _context.Projects!.Add(project);
            await _context.SaveChangesAsync(); // Save the project to get the ProjectId

            // Now create and link images using the ImageService
            var images = await _imageService.CreateImagesForProject(imageUrls, project.ProjectId, captions, alttexts);

            // Link images to the project
            project.Images = images;

            ProjectAddResponse response = project.ToProjectAddReponse();

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

            return projects;
        }

        public async Task<List<ProjectAddResponse>> LoadAdminProjects()
        {
            List<ProjectAddResponse> projects = await _context.Projects!
                .Include(p => p.Images)
                .Select(p => p.ToProjectAddReponse())
                .ToListAsync();  // Use ToListAsync() for async operation

            return projects;
        }

        public Task<List<Project>> GetSortedProjects(Sort sort)
        {
            throw new NotImplementedException();
        }
    }
}
