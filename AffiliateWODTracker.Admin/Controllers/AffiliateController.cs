using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.RequestModels;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Services.Interfaces;
using AffiliateWODTracker.Services.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AffiliateWODTracker.Admin.Controllers
{
    public class AffiliateController : Controller
    {
        private readonly IAffiliateManager _affiliateManager;

        public AffiliateController(IAffiliateManager affiliateManager)
        {
            _affiliateManager = affiliateManager;
        }
        [Authorize]
        public async Task<IActionResult> MyAffiliate()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get user ID from the logged-in user

            var affiliate = await _affiliateManager.GetAffiliateByUserId(userId);

            //if (affiliate == null)
            //{
            //    // If the user does not have an affiliate, redirect to the create page
            //    return RedirectToAction("CreateAffiliate");
            //}

            // If the user has an affiliate, pass the affiliate to the view
            return View(affiliate);
        }

        public async Task<IActionResult> CreateAffiliate()
        {
            // Only show the create page if the user does not already have an affiliate
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var affiliate = await _affiliateManager.GetAffiliateByUserId(userId);
            if (affiliate != null)
            {
                return RedirectToAction("MyAffiliate");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAffiliate(CreateAffiliateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var affiliate = new AffiliateEntity
                {
                    Name = model.Name,
                    Address = model.Address,
                    OwnerId = userId
                };

                // Save the affiliate to the database using your repository
                //await _affiliateRepository.AddAsync(affiliate);

                // Redirect to the appropriate action/page after creation
                return RedirectToAction("Index"); // or wherever you want to redirect
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


    }
}
