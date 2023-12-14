using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace AffiliateWODTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberManager _memberManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<MemberController> _logger;

        public MemberController(IMemberManager memberManager, UserManager<IdentityUser> userManager, ILogger<MemberController> logger)
        {
            _memberManager = memberManager;
            _userManager = userManager;
            _logger = logger;
        }

        [Authorize]
        [HttpGet(nameof(GetCurrentMember), Name = nameof(GetCurrentMember))]
        public async Task<IActionResult> GetCurrentMember()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    string userId = user.Id;
                    var member = await _memberManager.GetMemberByUserId(userId);
                    return Ok(member);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred retreiving member.");
                return StatusCode(500, new { Message = "An error occurred retreiving member." });
            }
            return BadRequest();
        }

    }
}
