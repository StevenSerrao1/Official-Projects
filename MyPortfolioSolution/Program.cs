using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add essential controller and view capabilities
builder.Services.AddControllers();

// Dynamically listen on the port provided by Render
builder.WebHost.ConfigureKestrel(options =>
{
    // Listen on 0.0.0.0 (any IP address) and port defined by Render
    var port = Environment.GetEnvironmentVariable("PORT") ?? "80"; // Default to 80 if PORT is not set
    options.Listen(IPAddress.Any, int.Parse(port)); // Listen on any IP address
});

builder.WebHost.UseUrls("http://0.0.0.0:" + Environment.GetEnvironmentVariable("PORT"));

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
