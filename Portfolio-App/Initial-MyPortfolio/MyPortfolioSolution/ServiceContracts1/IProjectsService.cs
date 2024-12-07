using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Models.Enums;
using MyPortfolioSolution.ViewModels;

namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IProjectsService
    {
        /// <summary>
        /// Adds a project to the database, can ONLY be called through Admin Portal
        /// </summary>
        /// <param name="name">Title of Project</param>
        /// <param name="description">Description of Project</param>
        /// <param name="imageUrls">Comma separated string of varying image urls</param>
        /// <param name="captions">Comma separated string of varying image captions</param>
        /// <param name="alttexts">Comma separated string of varying image alt-texts</param>
        /// <param name="projecturl">URL of project (host site)</param>
        /// <param name="githubreponame">Name of repo hosting the project</param>
        /// <returns></returns>
        public Task<ProjectAddResponse> AddProject(ProjectAddRequest par, string imageUrls, string captions, string alttexts);

        /// <summary>
        /// Loads a list of all projects currently in Projects DB (Available through CLIENT and ADMIN API)
        /// </summary>
        /// <returns>List<ProjectViewModel> reflecting all projects added</returns>
        public Task<List<ProjectViewModel>> LoadProjects();
        public Task<List<ProjectAddResponse>> LoadAdminProjects();

        /// <summary>
        /// Sort projects based on newest, oldest or most viewed on Github
        /// </summary>
        /// <param name="sort">Order of sorting for project view</param>
        /// <returns>Sorted List<Project> collection based on Sort enum</returns>
        public Task<List<Project>> GetSortedProjects(Sort sort);
    }
}
