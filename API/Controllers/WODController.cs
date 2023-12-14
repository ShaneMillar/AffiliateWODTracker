using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateWODTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WODController : Controller
    {
        private readonly IWODManager _wodManager;

        public WODController(IWODManager wodManager)
        {
            _wodManager = wodManager;
        }

        [HttpPost(nameof(PostWorkout), Name = nameof(PostWorkout))]
        public async Task<IActionResult> PostWorkout([FromBody] WODModel workout)
        {
            if (workout == null)
            {
                return BadRequest("Workout data is required.");
            }
            return Ok();
        }
    }
}
