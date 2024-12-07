using MyPortfolioSolution.Entities1;
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
        public async Task<List<Images>> CreateImagesForProject(string imageUrls, int projectId, string captions, string alttexts)
        {
            // Split the image URLs, captions, and alt texts by comma (or any delimiter)
            List<string> imageUrlsArray = imageUrls.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(url => url.Trim()) // Trim each URL
                                          .ToList();

            List<string> captionsArray = captions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(c => c.Trim())
                                              .ToList();

            List<string> alttextsArray = alttexts.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(a => a.Trim())
                                              .ToList();

            // Check for empty arrays
            if (!imageUrlsArray.Any() || !captionsArray.Any() || !alttextsArray.Any())
            {
                throw new ArgumentException("Image URLs, captions, and alt texts cannot be empty.");
            }

            // Ensure that the counts match; otherwise, handle appropriately (error or default value)
            if (imageUrlsArray.Count != captionsArray.Count || imageUrlsArray.Count != alttextsArray.Count)
            {
                // Handle the error (e.g., throw exception or return empty list)
                throw new ArgumentException("Number of URLs, captions, and alt texts must match.");
            }

            // Zip the three arrays together by first zipping two of them and then zipping the result with the third array
            List<Images> images = imageUrlsArray
                            .Zip(captionsArray, (url, caption) => new { url, caption })
                            .Zip(alttextsArray, (item, altText) => new Images
                            {
                                ImageUrl = item.url,
                                Caption = item.caption,
                                AltText = altText,
                                ProjectId = projectId
                            }).ToList();

            // Save the images to the database
            _context.Images!.AddRange(images);
            await _context.SaveChangesAsync();

            return images;
        }
    }
}
