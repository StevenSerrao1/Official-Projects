namespace MyPortfolioSolution.ServiceContracts1
{
    public interface IGitHubService
    {
        public Task<string> GetGitHubViewsAsync(string repoName);

    }
}
