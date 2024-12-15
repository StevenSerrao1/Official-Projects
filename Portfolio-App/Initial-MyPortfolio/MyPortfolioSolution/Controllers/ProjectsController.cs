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
        private readonly EmailService _emailService;

        public ProjectsController(ApplicationDbContext context, ILogger<ProjectsController> logger, IProjectsService projectsService, EmailService emailService)
        {
            _context = context;
            _logger = logger;
            _projectsService = projectsService;
            _emailService = emailService;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> ContactForm([FromBody] ContactViewModel model) // api/contact/contactform
        {
            try
            {
                if (await _emailService.SendEmailAsync(model.Name, model.Email, model.Message))
                {
                    return Ok(new { message = "Email sent successfully!" });
                }
                return StatusCode(500, new { message = "Email failed to send." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("Contact API is working!");
        }
    }


}