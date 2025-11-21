using System.Net;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.Services1;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

// Add essential controller and view capabilities
// This sets up the application to handle controllers and views (MVC pattern).
builder.Services.AddControllersWithViews();

// Add environment variables to configuration
// This ensures that environment variables are available throughout the app.
builder.Configuration.AddEnvironmentVariables();

// Configure Email service HTTP client with API key from environment variables

// DB SETUP SERVICES
// Retrieves the connection string from environment variables and sets up PostgreSQL.
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STR");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Configures the context to use PostgreSQL with the connection string.
    options.UseNpgsql(connectionString);
});

// ADD SERVICES
// Dependency Injection for various services
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<IImageService, ImageService>();

// Dynamically listen on the port provided by Render
// Grab the PORT env var (Render sets this), default to 5000 if missing
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Tell Kestrel to listen on any IP and that port
builder.WebHost
       .UseUrls($"http://*:{port}");

// Add routing capability
// This allows the app to route incoming requests to the appropriate controller.
builder.Services.AddRouting();

// Add Cross-Origin-Resource-Sharing (CORS) capability
// Configures CORS to allow specific origins to make requests to the backend.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://official-projects-1-frontend.onrender.com", "http://localhost:3000") // Allowed frontend URLs
              .AllowAnyHeader()  // Allow any headers in requests
              .AllowAnyMethod(); // Allow any HTTP methods (GET, POST, etc.)
    });
});

// Initialize app through builder.Build()
var app = builder.Build();

// Add error handling in development
if (app.Environment.IsDevelopment())
{
    // This middleware provides detailed error pages in development.
    app.UseDeveloperExceptionPage();
}

// Enable CORS
app.UseCors("AllowFrontend"); // Use the CORS policy defined earlier

// Enable routing
app.UseRouting(); // Enables routing capabilities for the app

// Enable Static file use
// Allows the app to serve static files like images, CSS, JavaScript, etc.
app.UseStaticFiles();

// Enable controller mapping
// Maps requests to controllers (MVC controller routing).
app.MapControllers();

// Run app
// Starts the web application, making it ready to accept requests.
app.Run();
