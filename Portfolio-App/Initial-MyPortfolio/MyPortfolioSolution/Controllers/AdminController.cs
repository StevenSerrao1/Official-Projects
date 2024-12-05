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

        [HttpPost("[action]")]
        public Task<IActionResult> CreateProject([FromBody] Project project)
        {
            // Dummy logic to return a successful response without doing actual processing
            var dummyProject = new Project
            {
                Title = "Dummy Project",
                Description = "This is a dummy project to avoid errors."
            };

            // Simulate async operation and return an Ok result with the dummy project
            return Task.FromResult<IActionResult>(Ok(dummyProject));
        }
    }
}
