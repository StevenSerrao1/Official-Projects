using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.Models.Enums;
using MyPortfolioSolution.ViewModels;

namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IProjectsService
    {
        /// <summary>
        /// Adds a project into the Projects DB (ONLY AVAILABLE THROUGH ADMIN API)
        /// </summary>
        /// <param name="name">Title of project being added</param>
        /// <param name="description">Description of project being added</param>
        /// <param name="images">List of Images type denoting images being linked to project</param>
        /// <returns>The Project object being added</returns>
        public Task<Project> AddProject(string name, string description, List<Images> images);

        /// <summary>
        /// Loads a list of all projects currently in Projects DB (Available through CLIENT and ADMIN API)
        /// </summary>
        /// <returns>List<ProjectViewModel> reflecting all projects added</returns>
        public Task<List<ProjectViewModel>> LoadProjects();

        /// <summary>
        /// Sort projects based on newest, oldest or most viewed on Github
        /// </summary>
        /// <param name="sort">Order of sorting for project view</param>
        /// <returns>Sorted List<Project> collection based on Sort enum</returns>
        public Task<List<Project>> GetSortedProjects(Sort sort);
    }
}
