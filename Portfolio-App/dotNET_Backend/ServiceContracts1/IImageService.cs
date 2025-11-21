using MyPortfolioSolution.DTO;
using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ServiceContracts1
{
    /// <summary>
    /// Interface defining the contract for image-related services.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Creates and associates images with a specified project in the database.
        /// </summary>
        /// <param name="imageRequests">A list of <see cref="ImageAddRequest"/> objects containing image details.</param>
        /// <param name="projectId">The unique identifier of the project to associate the images with.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Images"/> objects reflecting the created images.</returns>
        public Task<List<Images>> CreateImagesForProject(List<ImageAddRequest> imageRequests, int projectId);
    }
}
