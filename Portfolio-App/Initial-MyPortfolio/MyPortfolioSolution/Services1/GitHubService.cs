using Octokit;
using MyPortfolioSolution.ServiceContracts1;
using System.Collections.Concurrent;

namespace MyPortfolioSolution.Services1
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly string _owner;
        private readonly string? _personalAccessToken;

        // Caching GitHub views data in-memory with expiration time (e.g., 10 minutes)
        private static readonly ConcurrentDictionary<string, CachedGitHubViewData> _viewCache = new ConcurrentDictionary<string, CachedGitHubViewData>();
        private static readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(10);

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
            try
            {
                // Check if data is cached and still valid
                if (_viewCache.TryGetValue(repoName, out var cachedData) &&
                    cachedData != null &&
                    (DateTime.Now - cachedData.Timestamp) < _cacheExpirationTime)
                {
                    Console.WriteLine("Returning cached data.");
                    return cachedData.Data; // Return cached data if available and within TTL
                }

                // Create the request for traffic data
                var request = new RepositoryTrafficRequest(TrafficDayOrWeek.Week);

                // Use Task.WhenAny() to handle timeout without passing CancellationToken to GetViews()
                var trafficTask = _client.Repository.Traffic.GetViews(_owner, repoName, request);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5));  // Timeout after 5 seconds

                var completedTask = await Task.WhenAny(trafficTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    // Timeout logic
                    Console.WriteLine("GitHub view request timed out.");
                    return "GitHub view request timed out.";
                }

                // Wait for the trafficTask to complete (it should be completed by now)
                var traffic = await trafficTask;

                var viewData = $"Total Views: {traffic.Count}, Unique Visitors: {traffic.Uniques}";

                // Cache the response with timestamp
                _viewCache[repoName] = new CachedGitHubViewData
                {
                    Data = viewData,
                    Timestamp = DateTime.Now
                };

                return viewData;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                return "Failed to retrieve data.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return "An error occurred.";
            }
        }

        // Helper class for caching
        private class CachedGitHubViewData
        {
            public string? Data { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}
