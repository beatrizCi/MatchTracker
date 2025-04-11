using MatchTracker.Core.Models;
using MatchTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class ClubStatsController : ControllerBase
{
    private readonly MatchContext _context;

    public ClubStatsController(MatchContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetStats()
    {
        var stats = await _context.ClubStats.ToListAsync();
        return Ok(stats);
    }
}