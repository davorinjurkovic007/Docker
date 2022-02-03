var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;

var server = configuration["DBServer"] ?? "localhost";
var port = configuration["DBPort"] ?? "1443";
// Do not do this in PRODUCTION. This is here just for the simplisity
var user = configuration["DBUser"] ?? "SA";
var password = configuration["DBPassword"] ?? "Pa$$w0rd2019";

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

app.Run();
