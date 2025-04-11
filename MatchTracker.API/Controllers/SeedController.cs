using MatchTracker.Infrastructure.Data;
using MatchTracker.Infrastructure.Seeders;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly MatchContext _context;

    public SeedController(MatchContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Seed()
    {
        try
        {
            DataSeeder.Seed(_context);
            return Ok("✅ Seeding completed successfully.");
        }
        catch (Exception ex)
        {
            var fullError = $@"
❌ Seeding failed:
{ex.Message}
{ex.InnerException?.Message}
{ex.InnerException?.InnerException?.Message}
";

            return StatusCode(500, fullError);
        }
    }

}
