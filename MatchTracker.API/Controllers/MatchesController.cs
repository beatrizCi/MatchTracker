using MatchTracker.Core.Interfaces;
using MatchTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        [HttpGet("{day}")]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchesByDay(int day)
        {
            var matches = await _matchService.GetMatchesByDayAsync(day);
            if (matches == null || !matches.Any())
            {
                return NotFound("No matches available for the selected day.");
            }
            return Ok(matches);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportMatches([FromBody] List<Match> matches)
        {
            await _matchService.ImportMatchesAsync(matches);
            return Ok();
        }
    }
}
