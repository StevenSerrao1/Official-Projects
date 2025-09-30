using Octokit;
using MyPortfolioSolution.ServiceContracts1;
using System.Collections.Concurrent;

namespace MyPortfolioSolution.Services1
{
    public class GitHubService : IGitHubService
    {
        // GitHub client to interact with the GitHub API
        private readonly GitHubClient _client;

        // Owner of the repositories (GitHub username)
        private readonly string _owner;

        // Personal Access Token for authentication with the GitHub API
        private readonly string? _personalAccessToken;

        // In-memory cache for storing GitHub views data with expiration
        private static readonly ConcurrentDictionary<string, CachedGitHubViewData> _viewCache = new ConcurrentDictionary<string, CachedGitHubViewData>();

        // Time duration before the cached data expires
        private static readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(10);

        // Constructor to initialize the service
        public GitHubService(IConfiguration config)
        {
            _owner = "StevenSerrao1"; // Hardcoded GitHub owner name
            _personalAccessToken = Environment.GetEnvironmentVariable("REPOPublicAccessToken"); // Retrieve token from environment variables

            // Logging the personal access token for debugging purposes
            Console.WriteLine($"GitHub Personal Access Token: '{_personalAccessToken}'");

            // Validate if the token is present
            if (string.IsNullOrEmpty(_personalAccessToken))
            {
                throw new ArgumentException("GitHub Personal Access Token cannot be empty.", nameof(_personalAccessToken));
            }

            // Initialize the GitHubClient with the token for authentication
            _client = new GitHubClient(new ProductHeaderValue("MyApp"))
            {
                Credentials = new Credentials(_personalAccessToken)
            };
        }

        // Method to retrieve GitHub traffic views data for a specific repository
        public async Task<string> GetGitHubViewsAsync(string repoName)
        {
            try
            {
                // Check if the requested repository's views data is cached and still valid
                if (_viewCache.TryGetValue(repoName, out var cachedData) &&
                    cachedData != null &&
                    (DateTime.Now - cachedData.Timestamp) < _cacheExpirationTime)
                {
                    Console.WriteLine("Returning cached data.");
                    return cachedData.Data; // Return cached data if available and within time-to-live
                }

                // Create a request for repository traffic data with a weekly time span
                var request = new RepositoryTrafficRequest(TrafficDayOrWeek.Week);

                // Initiate the API call and set a timeout for 5 seconds
                var trafficTask = _client.Repository.Traffic.GetViews(_owner, repoName, request);
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5)); // Timeout task

                // Wait for either the traffic data task or the timeout to complete
                var completedTask = await Task.WhenAny(trafficTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    // Handle the case where the GitHub API call times out
                    Console.WriteLine("GitHub view request timed out.");
                    return "GitHub view request timed out.";
                }

                // Retrieve the traffic data after ensuring the API call completed successfully
                var traffic = await trafficTask;

                // Format the traffic data into a user-friendly string
                var viewData = $"Total Views: {traffic.Count}, Unique Visitors: {traffic.Uniques}";

                // Cache the response for the repository with the current timestamp
                _viewCache[repoName] = new CachedGitHubViewData
                {
                    Data = viewData,
                    Timestamp = DateTime.Now
                };

                return viewData;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request-related errors
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
                // Handle general unexpected errors
                Console.WriteLine($"General Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return "An error occurred.";
            }
        }

        // Helper class for caching GitHub views data
        private class CachedGitHubViewData
        {
            public string? Data { get; set; } // The cached data (views information)
            public DateTime Timestamp { get; set; } // Timestamp when the data was cached
        }
    }
}
