using MatchTracker.Core.Interfaces;
using MatchTracker.Infrastructure.Data;
using MatchTracker.Infrastructure.Repositories;
using MatchTracker.Infrastructure.Seeders;
using MatchTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MatchContext>(options =>
    options.UseNpgsql(connectionString));


// ✅ Register dependencies
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMatchService, MatchService>();

// ✅ Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowALL", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ✅ Swagger in dev
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Run migrations and seed (⚠️ no delete!)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MatchContext>();

    context.Database.Migrate();        // Apply migrations
    DataSeeder.Seed(context);         // Seed initial data
}

// ✅ Middleware
app.UseCors("AllowALL");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
