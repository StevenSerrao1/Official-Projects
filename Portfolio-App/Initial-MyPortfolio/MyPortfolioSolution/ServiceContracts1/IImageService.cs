using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IImageService
    {
        public Task<List<Images>> CreateImagesForProject(string imageUrls, int projectId, string captions, string alttexts);
    }
}
