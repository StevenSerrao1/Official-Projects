using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add essential controller and view capabilities
builder.Services.AddControllers();

// Listen on strictly HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 7199); // HTTP
});

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

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable Static file use
app.UseStaticFiles();

// Enable controller mapping
app.MapControllers();

// Run app
app.Run();
