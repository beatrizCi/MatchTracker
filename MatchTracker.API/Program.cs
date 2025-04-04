using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Data;
using MatchTracker.Infrastructure.Repositories;
using MatchTracker.Infrastructure.Seeders;
using MatchTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<MatchContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and unit of work
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMatchService, MatchService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowALL", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MatchContext>();
    context.Database.EnsureDeleted(); // Ensure the database is deleted
    context.Database.Migrate(); // Apply any pending migrations
    DataSeeder.Seed(context); // Seed the database
}

app.UseCors("AllowALL");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
