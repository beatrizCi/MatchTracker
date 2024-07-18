namespace MatchTracker.Infrastructure.Configuration
{
    using MatchTracker.Infrastructure.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class CreateSqLiteDb
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MatchContext>();
                context.Database.EnsureCreated(); // Creates the database if it doesn't exist
            }
        }
    }
}
