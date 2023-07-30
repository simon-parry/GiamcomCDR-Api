using GiacomCDR_Api;
using GiacomCDR_Api.Dependancies;
using GiacomCDR_Api.Middleware;
using GiacomCDR_Api.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

Dependencies.RegisterDependencies(builder.Services);

// The following configures EF to create a Sqlite database file in the
// special "local" folder for your platform.
var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "GiacomDbTest.db");
builder.Services.AddDbContext<GiacomDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddlewareExtensions>();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<GiacomDbContext>();
    var seedData = new SeedData(dbContext);
    seedData.Seed();
}

app.Run();
