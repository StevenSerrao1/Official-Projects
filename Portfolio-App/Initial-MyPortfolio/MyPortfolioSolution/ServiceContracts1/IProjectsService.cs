using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Models.Enums;
using MyPortfolioSolution.ViewModels;

namespace MyPortfolioSolution.ServiceContracts1
{
    /// <summary>
    /// Interface defining the contract for project-related services.
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// Adds a new project to the database.
        /// This method should only be called through the Admin Portal.
        /// </summary>
        /// <param name="par">An object of type <see cref="ProjectAddRequest"/> containing project details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an object of type <see cref="ProjectAddResponse"/>.</returns>
        public Task<ProjectAddResponse> AddProject(ProjectAddRequest par);

        /// <summary>
        /// Loads all projects currently stored in the database.
        /// This method is accessible through both Client and Admin APIs.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="ProjectViewModel"/> reflecting all projects.</returns>
        public Task<List<ProjectViewModel>> LoadProjects();

        /// <summary>
        /// Loads all projects currently stored in the database with additional admin-specific details.
        /// This method is accessible only through the Admin API.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="ProjectAddResponse"/> with admin-specific data.</returns>
        public Task<List<ProjectAddResponse>> LoadAdminProjects();

        /// <summary>
        /// Retrieves a project by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Project"/> with the specified ID.</returns>
        public Task<Project> GetProjectById(int? id);

        /// <summary>
        /// Deletes a project from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the deletion was successful.</returns>
        public Task<bool> DeleteProject(int? id);

        /// <summary>
        /// Updates the details of an existing project.
        /// </summary>
        /// <param name="project">An object of type <see cref="ProjectAddResponse"/> containing the updated project details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="ProjectAddResponse"/>.</returns>
        public Task<ProjectAddResponse> UpdateProject(ProjectAddResponse? project);
    }
}
