using AffiliateWODTracker.Core.RequestModels;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace AffiliateWODTracker.Admin.Controllers
{
    public class MembersController : Controller
    {
        private readonly IAffiliateManager _affiliateManager;
        private readonly IMemberManager _memberManager;

        public MembersController(IAffiliateManager affiliateManager, IMemberManager memberManager)
        {
            _affiliateManager = affiliateManager;
            _memberManager = memberManager;
        }

        public async Task<IActionResult> MyMembers()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get user ID from the logged-in user
            var affiliate = await _affiliateManager.GetAffiliateByUserId(userId);

            //Get Members by AffiliateId
           var members = await _memberManager.GetMembersByAffiliateId(affiliate.AffiliateId);

            return View(members); //Pass in list of MemberViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMember([FromBody] DeleteMemberRequest member)
        {
            await _memberManager.DeleteMember(member.MemberId);

            return RedirectToAction("MyAffiliate");

        }
    }
}
