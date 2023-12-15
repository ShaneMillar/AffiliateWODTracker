using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateWODTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WODController : Controller
    {
        private readonly IWODManager _wodManager;
        private readonly ILogger<WODController> _logger;

        public WODController(IWODManager wodManager, ILogger<WODController> logger)
        {
            _wodManager = wodManager;
            _logger = logger;
        }

        [Authorize]
        [HttpPost(nameof(PostWorkout), Name = nameof(PostWorkout))]
        public async Task<IActionResult> PostWorkout([FromBody] WODModel workout)
        {
            if (workout == null)
            {
                return BadRequest("Workout data is required.");
            }
            try
            {
               await _wodManager.CreateWOD(workout);
                return Ok(new { Message = "WOD Creation successful." });

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred during WOD creation.");
                return StatusCode(500, new { Message = "An error occurred during WOD creation." });
            }
        }

        [Authorize]
        [HttpGet(nameof(GetWODsByAffiliateId), Name = nameof(GetWODsByAffiliateId))]
        public async Task<IActionResult> GetWODsByAffiliateId([FromQuery] int affiliateId)
        {
            try
            {
               var workouts =  await _wodManager.GetWODsByAffiliateId(affiliateId);
                return Ok(workouts);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred retrieving workouts.");
                return StatusCode(500, new { Message = "An error occurred retrieving workouts." });
            }

        }
    }
}
