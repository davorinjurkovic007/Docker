// Youtube:  Les Jackson
// Docker Compose with .NET Core & SQL Server (Step by Step)
// https://www.youtube.com/watch?v=4V7CwC_4oss

using DockerAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;

var server = configuration["DBServer"] ?? "localhost"; // Docker composer don't know what is "localhost", so we have to use "ms-sql-server" if we want to connect to containter
var port = configuration["DBPort"] ?? "1433";
// Do not do this in PRODUCTION. This is here just for the simplisity
var user = configuration["DBUser"] ?? "SA";
var password = configuration["DBPassword"] ?? "yourStrong(!)Password";
var database = configuration["Database"] ?? "Colours";

builder.Services.AddDbContext<ColourContext>(options =>
{
    options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

PrepDB.PrepPopulation(app);

app.Run();
