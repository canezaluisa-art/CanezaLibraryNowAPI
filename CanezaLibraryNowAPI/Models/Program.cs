var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();

// Render port setup


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
// ALWAYS enable Swagger (not only dev)
app.UseSwagger();
app.UseSwaggerUI();

// Optional: HTTPS redirect (can keep, but Render already handles HTTPS)
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
// ⭐ ADD ROOT ROUTE (THIS FIXES YOUR 404)
app.MapGet("/", () => "CanezaLibraryNowAPI is running 🚀");

// Controllers
app.MapControllers();

app.Run();