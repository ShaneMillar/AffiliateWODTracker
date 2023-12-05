using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Services.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AffiliateWODTracker.Admin.Controllers
{
    public class AffiliateController : Controller
    {
        private readonly AffiliateManager _affiliateManager;

        public AffiliateController(AffiliateManager affiliateManager)
        {
            _affiliateManager = affiliateManager;
        }
        [Authorize]
        public IActionResult MyAffiliate()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get user ID from the logged-in user

            var affiliate = _affiliateManager.GetAffiliateByUserId(userId);

            if (affiliate == null)
            {
                // If the user does not have an affiliate, redirect to the create page
                return RedirectToAction("CreateAffiliate");
            }

            // If the user has an affiliate, pass the affiliate to the view
            return View(affiliate);
        }

        public IActionResult CreateAffiliate()
        {
            // Only show the create page if the user does not already have an affiliate
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var affiliate = _affiliateManager.GetAffiliateByUserId(userId);
            if (affiliate != null)
            {
                return RedirectToAction("MyAffiliate");
            }

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateAffiliate(CreateAffiliateViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var newAffiliate = new Affiliate
        //        {
        //            // Set properties based on the form's ViewModel
        //            Name = model.Name,
        //            Address = model.Address,
        //        };


        //        _context.Affiliates.Add(newAffiliate);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("MyAffiliate");
        //    }

        //    return View(model);
        //}

    }
}
