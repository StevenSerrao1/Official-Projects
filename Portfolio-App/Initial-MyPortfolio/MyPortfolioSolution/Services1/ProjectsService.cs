
using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.Services1
{
    public class ProjectsService
    {
        private readonly ApplicationDbContext _context;

        public ProjectsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProject(string name, string description)
        {
            var project = new Project
            {
                Name = name,
                Description = description
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task AddProjectWithImages(string name, string description, List<Images> images)
        {
            // Create the project
            var project = new Project
            {
                Name = name,
                Description = description,
                Images = images // This adds the associated images to the project
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

    }
}
