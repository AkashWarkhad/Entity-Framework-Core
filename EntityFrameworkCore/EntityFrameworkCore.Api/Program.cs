using EntityFrameworkCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlliteDatabaseName = builder.Configuration.GetConnectionString("SqliteDatabaseConnectionString");

var folder = Environment.SpecialFolder.ApplicationData;
var path = Environment.GetFolderPath(folder);
var DbPath = Path.Combine(path, sqlliteDatabaseName);

var connectionString = $"Data Source={DbPath}";

builder.Services.AddDbContext<FootballLeagueDbContext>(options =>
{
    options.UseSqlite(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //<- DO not track the query just read it and that sit. Its Quicker
    
    if (!builder.Environment.IsProduction())
    {
        // You can register alone as well
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Add DbContext 
builder.Services.AddDbContext<FootballLeagueDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
