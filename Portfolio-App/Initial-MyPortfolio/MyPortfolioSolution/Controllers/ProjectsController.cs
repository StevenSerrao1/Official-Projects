using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.Services1;
using MyPortfolioSolution.ViewModels;

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
        private readonly EmailService _emailService;

        // Constructor for dependency injection
        public ProjectsController(ApplicationDbContext context, ILogger<ProjectsController> logger, IProjectsService projectsService, EmailService emailService)
        {
            _context = context;           // Injecting the ApplicationDbContext for database access
            _logger = logger;             // Injecting the Logger for error logging
            _projectsService = projectsService;  // Injecting the ProjectsService for business logic
            _emailService = emailService;        // Injecting the EmailService to send emails
        }

        // Action to load all projects
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadProjects() // api/projects/loadprojects
        {
            try
            {
                // Call the service to load projects asynchronously
                List<ProjectViewModel> projects = await _projectsService.LoadProjects();
                return Ok(projects);  // Return the list of projects with HTTP status 200 (OK)
            }
            catch (Exception ex)
            {
                // Log any errors that occur
                _logger.LogError(ex, "An error occurred while loading projects.");
                return StatusCode(500, "Internal server error");  // Return 500 if an error occurs
            }
        }

        // Action to handle contact form submissions
        [HttpPost("[action]")]
        public async Task<IActionResult> ContactForm([FromBody] ContactViewModel model) // api/contact/contactform
        {
            try
            {
                // Send email using the EmailService
                if (await _emailService.SendEmailAsync(model.Name, model.Email, model.Message))
                {
                    return Ok(new { message = "Email sent successfully!" });  // Return success message
                }
                return StatusCode(500, new { message = "Email failed to send." });  // Return error if email sending fails
            }
            catch (Exception ex)
            {
                // Log any errors and display the error message
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }

        // Simple test endpoint to confirm the API is working
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("Contact API is working!");  // Returns a simple message for testing purposes
        }
    }
}
