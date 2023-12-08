using AffiliateWODTracker.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AffiliateWODTracker.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpPost(nameof(Register), Name = nameof(Register))]
        public IActionResult Register(RegisterModel userRegistration)
        {
            var x = userRegistration;
            return Ok(userRegistration);
        }
    }
}
