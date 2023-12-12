using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateWODTracker.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMemberManager _memberManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMemberManager memberManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _memberManager = memberManager;
            _logger = logger;
        }


        [HttpPost(nameof(Register), Name = nameof(Register))]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var member = new Member
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    AffiliateId = model.AffiliateId.Value,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    StatusId = (int)MemberStatus.Pending,
                    CreatedDate = DateTime.Now,
                    UserId = user.Id
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    // If failed, return the errors.
                    return BadRequest(result.Errors.Select(e => e.Description));
                }

                await _memberManager.CreateMember(member);

                return Ok(new { Message = "Registration successful." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration.");
                return StatusCode(500, new { Message = "An error occurred during registration." });
            }
        }

        [HttpPost(nameof(Login), Name = nameof(Login))]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return Ok(new { Message = "Login successful." });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during registration.");
                    return StatusCode(500, new { Message = "An error occurred during Login." });
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [HttpPost(nameof(Logout), Name = nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            var result = _signInManager.SignOutAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Ok(new { Message = "Login successful." });
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
