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
            return StatusCode(500, $"❌ Seeding failed:\n{ex.Message}\n{ex.InnerException?.Message}");
        }
    }
}
