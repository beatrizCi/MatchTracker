using MatchTracker.Core.Models;
using MatchTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;


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
        var stats = _context.ClubStats.AsEnumerable().ToList(); 
        return Ok(stats);
    }
}