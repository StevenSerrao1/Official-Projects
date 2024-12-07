using Octokit;
using MyPortfolioSolution.ServiceContracts1;

namespace MyPortfolioSolution.Services1
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly string _owner;
        private readonly string? _personalAccessToken;

        public GitHubService(IConfiguration config)
        {
            _owner = "StevenSerrao1";
            _personalAccessToken = Environment.GetEnvironmentVariable("REPOPublicAccessToken");
            Console.WriteLine($"GitHub Personal Access Token: '{_personalAccessToken}'");

            if (string.IsNullOrEmpty(_personalAccessToken))
            {
                throw new ArgumentException("GitHub Personal Access Token cannot be empty.", nameof(_personalAccessToken));
            }
            _client = new GitHubClient(new ProductHeaderValue("MyApp"))
            {
                Credentials = new Credentials(_personalAccessToken)
            };            
        }

        public async Task<string> GetGitHubViewsAsync(string repoName)
        {

            var request = new RepositoryTrafficRequest(TrafficDayOrWeek.Week);

            var traffic = await _client.Repository.Traffic.GetViews(_owner, repoName, request);

            return $"Total Views: {traffic.Count}, Unique Visitors: {traffic.Uniques}";
        }
    }
}
