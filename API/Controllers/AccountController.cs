using AffiliateWODTracker.Auth.Authenticate;
using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        private readonly IConfiguration configuration;
        private readonly JWTValidationService _jwtMiddleware;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMemberManager memberManager, ILogger<AccountController> logger, IConfiguration configuration, JWTValidationService jwtMiddleware)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _memberManager = memberManager;
            _logger = logger;
            this.configuration = configuration;
            _jwtMiddleware = jwtMiddleware;
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
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        if (user != null)
                        {
                            var token =  _jwtMiddleware.GenerateJwtToken(user.Id);
                            return Ok(new { Token = token, Message = "Login successful." });
                        }
                        return BadRequest(new { Message = "User not found." });
                    }
                    else
                    {
                        return BadRequest(new { Message = "Invalid login attempt." });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during login.");
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
                return Ok(new { Message = "Logout successful." });
            }
            else
            {
                _logger.LogError("An error occurred during logout.");
                return StatusCode(500, new { Message = "An error occurred during logout." });
            }
        }



      

    }
}
