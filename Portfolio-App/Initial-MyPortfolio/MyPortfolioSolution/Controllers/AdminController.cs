using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult LoadAdminProjects() // api/admin/loadadminprojects
        {
            return View();
        }

        // TURN BACK INTO POST METHOD AND MOCK A BASIC PROJECT ADDITION
        [HttpGet("[action]")]
        public IActionResult CreateProject()
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
