using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.Models.Enums;
using MyPortfolioSolution.ViewModels;
using MyPortfolioSolution.ServiceContracts1;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolioSolution.Services1
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApplicationDbContext _context;

        public ProjectsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddProject(string name, string description, List<Images> images)
        {
            // Create the project
            Project project = new Project
            {
                Title = name,
                Description = description,
                Images = images // This adds the associated images to the project
            };

            _context.Projects.Add(project);

            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<List<ProjectViewModel>> LoadProjects()
        {
            List<ProjectViewModel> projects = await _context.Projects
                .Include(p => p.Images)
                .Select(p => p.ToProjectModel())
                .ToListAsync();  // Use ToListAsync() for async operation

            return projects;
        }

        public Task<List<Project>> GetSortedProjects(Sort sort)
        {
            throw new NotImplementedException();
        }
    }
}
