using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.ViewModels;

namespace MyPortfolioSolution.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IProjectsService _projectsService;

        public AdminController(IProjectsService proj)
        {
            _projectsService = proj;
        }

        [HttpGet("/")]
        public async Task<IActionResult> AdminPanel()
        {
            List<ProjectAddResponse> projects = await _projectsService.LoadAdminProjects();
            
            return View(projects);
        }

        [HttpGet("[action]")] // admin/createprojectget
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult CreateProject([FromForm] ProjectAddRequest par, [FromForm]  List<ImageAddRequest> iar)
        {
            // Dummy logic to return a successful response without doing actual processing
            Project dummyProject = new Project
            {
                Title = "Dummy Project",
                Description = "This is a dummy project to avoid errors."
            };

            // Simulate async operation and return an Ok result with the dummy project
            return Ok(dummyProject);
        }
    }
}
