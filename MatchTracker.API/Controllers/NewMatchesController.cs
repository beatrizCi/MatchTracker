using MatchTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewMatchesController : ControllerBase
    {
        private readonly MatchContext _context;

        public NewMatchesController(MatchContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNewMatches()
        {
            var matches = await _context.NewMatches.ToListAsync();
            return Ok(matches);
        }
    }
}
