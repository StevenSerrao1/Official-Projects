using System.Net;
using Microsoft.EntityFrameworkCore;
using Entities;
using Npgsql;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

// Add essential controller and view capabilities
builder.Services.AddControllers();

// ADD SERVICES
// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

// DB SETUP SERVICES
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STR");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// Dynamically listen on the port provided by Render
//builder.WebHost.ConfigureKestrel(options =>
//{
//    // Listen on 0.0.0.0 (any IP address) and port defined by Render
//    var port = Environment.GetEnvironmentVariable("PORT") ?? "80"; // Default to 80 if PORT is not set
//    options.Listen(IPAddress.Any, int.Parse(port)); // Listen on any IP address
//});

// Add routing capability
builder.Services.AddRouting();

// Add Cross-Origin-Resource-Sharing (CORS) capability
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Initialize app through builder.Build()
var app = builder.Build();

// Add error handling in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //Console.WriteLine($"Database Host: {Environment.GetEnvironmentVariable("DATABASE_HOST")}");
    //Console.WriteLine($"Database Name: {Environment.GetEnvironmentVariable("DATABASE_NAME")}");
    //Console.WriteLine($"Database User: {Environment.GetEnvironmentVariable("DATABASE_USER")}");
    //Console.WriteLine($"Database Password: {Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}");
    Console.WriteLine($"Connection Str: {Environment.GetEnvironmentVariable("CONNECTION_STR")}");
}

// Enable CORS
app.UseCors("AllowFrontend");

// Enable routing
app.UseRouting();

// You can remove HTTPS redirection if not configured in Render
// app.UseHttpsRedirection(); 

// Enable Static file use
app.UseStaticFiles();

// Enable controller mapping
app.MapControllers();

// Run app
app.Run();
