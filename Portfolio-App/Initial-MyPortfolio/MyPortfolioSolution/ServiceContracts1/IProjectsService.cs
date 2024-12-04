using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IProjectsService
    {
        public Task AddProject(string name, string description);

        public Task AddProjectWithImages(string name, string description, List<Images> images);
    }
}
