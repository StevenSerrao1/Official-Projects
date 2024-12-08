using MyPortfolioSolution.Entities1;

namespace MyPortfolioSolution.DTO
{
    public class ProjectAddRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProjectURL { get; set; } = string.Empty;
        public string GitHubRepoName { get; set; } = string.Empty;   
    }

    public static class ProjectRequestExtensions
    {
        public static Project ToProject(this ProjectAddRequest par)
        {
            return new Project
            {
                Title = par.Title,
                Description = par.Description,
                ProjectURL = par.ProjectURL,
                GitHubRepoName = par.GitHubRepoName,
            };
        }
    };

}
