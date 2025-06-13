using BirdWatching.Data;
using BirdWatching.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirdWatching.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SightingsController : ControllerBase
    {
        private readonly BirdWatchingDbContext _context;
        public SightingsController(BirdWatchingDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Sighting>> GetSightingAsync()
        {
            return await _context.Sightings.FirstAsync();
        }
    }
}
