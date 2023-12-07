using AffiliateWODTracker.Core.RequestModels;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AffiliateWODTracker.Admin.Controllers
{
    public class AffiliateController : Controller
    {
        private readonly IAffiliateManager _affiliateManager;
        private readonly IMemberManager _memberManager;
        public AffiliateController(IAffiliateManager affiliateManager, IMemberManager memberManager)
        {
            _affiliateManager = affiliateManager;
            _memberManager = memberManager;
        }
        [Authorize]
        public async Task<IActionResult> MyAffiliate()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get user ID from the logged-in user

            var affiliate = await _affiliateManager.GetAffiliateByUserId(userId);

            affiliate.ActiveMembersCount = await _memberManager.GetActiveMembersCountByAffiliateId(affiliate.AffiliateId);
            affiliate.PendingRequestsCount = await _memberManager.GetPendingRequestsCountByAffiliateId(affiliate.AffiliateId);


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
                await _affiliateManager.CreateAffiliate(affiliate);

                // Redirect to the appropriate action/page after creation
                return RedirectToAction("MyAffiliate"); // or wherever you want to redirect
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAffiliate([FromBody] DeleteAffiliateRequest affiliate)
        {
            await _affiliateManager.DeleteAffiliate(affiliate.AffiliateId);

            return RedirectToAction("MyAffiliate");

        }

    }
}
