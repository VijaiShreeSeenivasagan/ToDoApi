using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Data;
using Microsoft.OpenApi.Models;
using Data.Services;
using TodoApi.Data.Services;
using Serilog;
using TodoApi.Execptions;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Configuration.AddJsonFile("appsettings.json").Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();
//builder.Services.AddSerilog();

// Log.Logger = new LoggerConfiguration()
//     .WriteTo.File("Logs/log.txt")
//     .CreateLogger();
// builder.Services.AddSerilog();


builder.Services.AddDbContext<Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//Configure Services
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorService>();
builder.Services.AddTransient<PublisherService>();
var app = builder.Build();
//Initialise and seed database
//AppDbInitializer.Seed(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Set to empty string to serve at root
});
}

//configure exception handling
app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
