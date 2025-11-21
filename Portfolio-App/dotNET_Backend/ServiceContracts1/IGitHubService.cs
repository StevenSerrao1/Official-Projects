namespace MyPortfolioSolution.ServiceContracts1
{
    /// <summary>
    /// Interface defining the contract for GitHub-related services.
    /// </summary>
    public interface IGitHubService
    {
        /// <summary>
        /// Retrieves the number of views for a specified GitHub repository asynchronously.
        /// </summary>
        /// <param name="repoName">The name of the GitHub repository.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the view count as a string.</returns>
        public Task<string> GetGitHubViewsAsync(string repoName);
    }
}
