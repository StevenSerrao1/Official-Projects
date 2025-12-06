using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.Services1;
using MyPortfolioSolution.DTO;

namespace MyPortfolioSolution.Controllers
{
    // Specifies that this is an API controller and routes the requests to "api/[controller]"
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectsService _projectsService;

        // Constructor for dependency injection
        public ProjectsController(ApplicationDbContext context, ILogger<ProjectsController> logger, IProjectsService projectsService)
        {
            _context = context;           // Injecting the ApplicationDbContext for database access
            _logger = logger;             // Injecting the Logger for error logging
            _projectsService = projectsService;  // Injecting the ProjectsService for business logic
        }

        // Action to load all projects
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadProjects() // api/projects/loadprojects
        {
            try
            {
                // Call the service to load projects asynchronously
                List<ProjectAddResponse> projects = await _projectsService.LoadProjects();
                return Ok(projects);  // Return the list of projects with HTTP status 200 (OK)
            }
            catch (Exception ex)
            {
                // Log any errors that occur
                _logger.LogError(ex, "An error occurred while loading projects.");
                return StatusCode(500, "Internal server error");  // Return 500 if an error occurs
            }
        }
    }
}
