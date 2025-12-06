using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;

namespace MyPortfolioSolution.Controllers
{
    [Route("[controller]")] // admin
    public class AdminController : Controller
    {
        // Inject services below
        private readonly IProjectsService _projectsService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IProjectsService proj, ILogger<AdminController> logger)
        {
            _projectsService = proj;
            _logger = logger;
        }

        [HttpGet("/")] // localhost:5000
        public async Task<IActionResult> AdminPanel()
        {
            // Load all projects to view details upon visiting homepage
            List<ProjectAddResponse> projects = await _projectsService.LoadAdminProjects();

            return View(projects);
        }

        [HttpGet("/admin/project/{id:int}")]
        public async Task<IActionResult> LoadSingleProject(int id)
        {
            // Verify successful return of SINGLE PROJECT in db; returned in JSON format
            try
            {
                Project project = await _projectsService.GetProjectById(id);
                ProjectAddResponse projectAddResponse = project.ToProjectAddReponse();
                return Ok(projectAddResponse);
            }
            catch (Exception ex)
            {
                // Log the error (ex) here
                _logger.LogError(ex, "An error occurred while loading projects.");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("[action]")] // admin/loadadminprojects
        public async Task<IActionResult> LoadAdminProjects() // admin/loadadminprojects
        {
            // Verify successful return of projects in db; returned in JSON format
            try
            {
                List<ProjectAddResponse> projects = await _projectsService.LoadAdminProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                // Log the error (ex) here
                _logger.LogError(ex, "An error occurred while loading projects.");
                return StatusCode(500, "Internal server error");
            }
        }

        #region Create Controllers

        //[HttpGet("[action]")] // admin/createproject
        //public IActionResult CreateProject()
        //{
        //    return View(new ProjectAddRequest { Images = new List<ImageAddRequest>(new ImageAddRequest[2])});
        //}

        // Admin panel moved to a React frontend; CRUD endpoints now return and accept JSON.

        [HttpPost("[action]")] // admin/createproject/[post]
        public async Task<IActionResult> CreateProject([FromBody] ProjectAddRequest par)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                // Return validation errors as JSON
                return BadRequest(ModelState);
            }

            // Convert entity to DTO
            ProjectAddResponse projectAddResponse = await _projectsService.AddProject(par);

            // Return the created project as JSON
            return Ok(projectAddResponse);
        }

        #endregion

        //[HttpGet("[action]/{id?}")] // admin/deleteprojectget/{id}
        //public async Task<IActionResult> DeleteProjectGet(int? id)
        //{
        //    // Fetch project (by Id) to be deleted
        //    Project projectRetrieved = await _projectsService.GetProjectById(id);

        //    // Pass model data to View in order to load project details
        //    return View("Views/Admin/DeleteProject.cshtml", projectRetrieved);
        // }

         [HttpDelete("deleteproject/{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            // Return a BadRequest if the ID does not exist
            if (id <= 0) return BadRequest(new { message = "Invalid id" });

            // Check to see if project is deleted
            bool ok = await _projectsService.DeleteProject(id);

            // Handle error
            if (!ok) return NotFound(new { message = "Not found" });

            // Return JSON with confirmation
            return Ok(new { message = "Deleted" });
        }

        [HttpGet("[action]/{id}")] // GET: admin/updateproject/5
        public async Task<IActionResult> UpdateProject(int id)
        {
            // Fetch the existing project to confirm it exists
            Project? project = await _projectsService.GetProjectById(id);

            if (project == null) return NotFound(new { message = "Project not found" });

            // Convert Entity to DTO
            ProjectAddResponse par = project.ToProjectAddReponse();

            // Return JSON instead of a view
            return Ok(par);
        }


        [HttpPost("[action]/{id}")] // admin/updateproject/{id}/post
        public async Task<IActionResult> UpdateProject(ProjectAddResponse projectAdd)
        {
            // Fetch the existing project to confirm it exists
            Project? project = await _projectsService.GetProjectById(projectAdd.ProjectId);

            // Confirm project existence
            if (project == null) return BadRequest("The specified project does not exist.");
            
            // Service handles the update internally
            await _projectsService.UpdateProject(projectAdd);
            return RedirectToAction("AdminPanel");
        }

    }
}
