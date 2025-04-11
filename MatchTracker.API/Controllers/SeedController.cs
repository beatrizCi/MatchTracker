using MatchTracker.Infrastructure.Data;
using MatchTracker.Infrastructure.Seeders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchTracker.API.Controllers
{
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
                _context.Database.Migrate(); 
                DataSeeder.Seed(_context);   
                return Ok("✅ Database seeded successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Seeding failed: {ex.Message}");
            }
        }
    }
}
