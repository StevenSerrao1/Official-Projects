var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRouting();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapControllers();

app.Run();
