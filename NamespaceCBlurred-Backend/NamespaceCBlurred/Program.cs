using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NamespaceCBlurred.Business.Mappings;
using NamespaceCBlurred.Business.Services;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories;
using NamespaceCBlurred.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Change the connection string in appsettings.json.
builder.Services.AddDbContext<NamespaceCBlurredContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

// Here is the place where we do DI (Dependency Injection)

// Inject automappers
builder.Services.AddAutoMapper(typeof(SoundMappingProfile));

// Inject repositories
builder.Services.AddScoped<ISoundRepository, SoundRepository>();

// Inject services
builder.Services.AddScoped<ISoundService, SoundService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(c => c.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("Location"));

using (var scope = app.Services.CreateScope())
{
    try
    {
        // This ensures that the database is created, if it does not exist.
        var context = scope.ServiceProvider.GetService<NamespaceCBlurredContext>();
        context?.Database.EnsureCreated();
        context?.Database.Migrate();
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// Run
app.Run();
