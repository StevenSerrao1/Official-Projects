﻿using Microsoft.AspNetCore.Mvc;
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

    }
}
