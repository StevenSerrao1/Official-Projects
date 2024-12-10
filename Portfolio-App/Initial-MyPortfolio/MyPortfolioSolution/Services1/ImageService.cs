using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.DTO;
using MyPortfolioSolution.ServiceContracts1;
using System.Linq;

namespace MyPortfolioSolution.Services1
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;

        public ImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to process image URLs (split and trim), and create Image entities
        // Method to process ImageAddRequest objects and create Image entities
        public async Task<List<Images>> CreateImagesForProject(List<ImageAddRequest> imageRequests, int projectId)
        {
            if (imageRequests == null || !imageRequests.Any())
            {
                throw new ArgumentException("Image requests cannot be null or empty.");
            }

            // Convert ImageAddRequest objects to Images entities
            List<Images> images = imageRequests
                .Select(request => request.ToImages())
                .ToList();

            // Now set the projectId on each image
            foreach (var image in images)
            {
                image.ProjectId = projectId;
            }

            // Save the images to the database
            _context.Images!.AddRange(images);
            await _context.SaveChangesAsync();

            return images; // Return the Images entities
        }
    }
}
