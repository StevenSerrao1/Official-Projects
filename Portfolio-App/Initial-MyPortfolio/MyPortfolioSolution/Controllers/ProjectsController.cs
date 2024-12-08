using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.Services1;
using MyPortfolioSolution.ViewModels;

namespace MyPortfolioSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectsService _projectsService;

        public ProjectsController(ApplicationDbContext context, ILogger<ProjectsController> logger, IProjectsService projectsService)
        {
            _context = context;
            _logger = logger;
            _projectsService = projectsService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LoadProjects() // api/projects/loadprojects
        {
            try
            {
                List<ProjectViewModel> projects = await _projectsService.LoadProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                // Log the error (ex) here
                _logger.LogError(ex, "An error occurred while loading projects.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
