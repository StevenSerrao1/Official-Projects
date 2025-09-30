using Blazor_backend.Components;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using MyPortfolioSolution.Entities1;
using MyPortfolioSolution.ServiceContracts1;
using MyPortfolioSolution.Services1;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

// Add controllers ONLY — no views needed for Blazor Server
builder.Services.AddControllers();

// Add Razor Pages and Blazor Server support
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

// DB SETUP SERVICES
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STR");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// ADD SERVICES (DI)
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<IImageService, ImageService>();

// Dynamically listen on the port provided by Render or default to 5000
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

// Add routing and CORS policies
builder.Services.AddRouting();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://official-projects-1-frontend.onrender.com", "http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowFrontend");

app.UseStaticFiles();

app.UseRouting();

// Map your API controllers
app.MapControllers();

// **Map Blazor Hub for real-time connection**
app.MapBlazorHub();

// **Fallback all other routes to Blazor host page (_Host.cshtml)**
app.MapFallbackToPage("/_Host");

// Run the app
app.Run();
