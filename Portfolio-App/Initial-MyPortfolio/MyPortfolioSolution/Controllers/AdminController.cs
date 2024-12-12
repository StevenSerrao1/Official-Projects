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

        #region Create Controllers

        [HttpGet("[action]")] // admin/createproject
        public IActionResult CreateProject()
        {
            return View(new ProjectAddRequest { Images = new List<ImageAddRequest>(new ImageAddRequest[2]) });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProject(ProjectAddRequest par)
        {
            if(!ModelState.IsValid)
            {
                return View(par);
            }

            ProjectAddResponse projectAddResponse = await _projectsService.AddProject(par);

            return RedirectToAction("AdminPanel");
        }

        #endregion

        [HttpGet("[action]/{id?}")]
        public async Task<IActionResult> DeleteProjectGet(int? id)
        {
            Project projectRetrieved = await _projectsService.GetProjectById(id);

            return View("Views/Admin/DeleteProject.cshtml", projectRetrieved);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> DeleteProjectPost([FromForm] int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid project ID.";
                return RedirectToAction("AdminPanel");
            }

            bool deletion = await _projectsService.DeleteProject(id);

            if (!deletion)
            {
                TempData["ErrorMessage"] = "Failed to delete the project.";
                return RedirectToAction("AdminPanel");
            }

            TempData["SuccessMessage"] = "Project deleted successfully.";
            return RedirectToAction("AdminPanel");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> UpdateProject(int id)
        {
            Project? project = await _projectsService.GetProjectById(id);

            ProjectAddResponse par = project.ToProjectAddReponse();

            return View(par);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> UpdateProject(ProjectAddResponse projectAdd)
        {
            // Fetch the existing project to confirm it exists
            Project? project = await _projectsService.GetProjectById(projectAdd.ProjectId);


            if (project == null)
            {
                return BadRequest("The specified project does not exist.");
            }

            // Service handles the update internally
            await _projectsService.UpdateProject(projectAdd);
            return RedirectToAction("AdminPanel");
        }

    }
}
