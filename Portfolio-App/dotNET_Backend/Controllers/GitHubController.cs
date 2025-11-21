using Microsoft.AspNetCore.Mvc;
using MyPortfolioSolution.ServiceContracts1;

namespace MyPortfolioSolution.Controllers
{
    [Route("api/[controller]")] // api/github
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        // Endpoint to get GitHub views for a specific repo
        [HttpGet("[action]/{repoName}")] // api/github/getgithubviews/{repoName}
        public async Task<IActionResult> GetGitHubViews(string repoName)
        {
            try
            {
                var views = await _gitHubService.GetGitHubViewsAsync(repoName);
                return Ok(views);  // Return the view data as a response
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
