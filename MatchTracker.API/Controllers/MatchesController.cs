using MatchTracker.Core.Interfaces;
using MatchTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatchTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("{matchDay}")]
        public async Task<IActionResult> GetMatchesByDay(int matchDay)
        {
            var matches = await _matchService.GetMatchesByDayAsync(matchDay);
            if (!matches.Any())
            {
                return NotFound("No matches available for the selected day.");
            }
            var sortedMatches = matches.OrderByDescending(m => m.KickOffTime).ToList();
            return Ok(sortedMatches);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportMatches([FromBody] List<Match> matches)
        {
            await _matchService.ImportMatchesAsync(matches);
            return Ok();
        }
    }
}
