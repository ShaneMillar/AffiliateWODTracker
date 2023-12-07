using AffiliateWODTracker.Core.RequestModels;
using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

            if (affiliate != null)
            {
                //Get Members by AffiliateId
                var members = await _memberManager.GetMembersByAffiliateId(affiliate.AffiliateId);
                return View(members); //Pass in list of MemberViewModel
            }
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveMember([FromBody] MemberActionRequest member)
        {
            await _memberManager.UpdateMemberToPending(member.MemberId);

            return RedirectToAction("MyMembers");

        }

        public async Task<IActionResult> MyRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get user ID from the logged-in user
            var affiliate = await _affiliateManager.GetAffiliateByUserId(userId);

            if (affiliate != null)
            {
                //Get Requested Members by AffiliateId
                var members = await _memberManager.GetRequestedMembersByAffiliateId(affiliate.AffiliateId);

                return View(members); //Pass in list of MemberViewModel
            }
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptMember([FromBody] MemberActionRequest memberRequest)
        {
            await _memberManager.UpdateMemberToAccepted(memberRequest.MemberId);

            return RedirectToAction("MyRequests");

        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectMember([FromBody] MemberActionRequest memberRequest)
        {
            await _memberManager.UpdateMemberToRejected(memberRequest.MemberId);

            return RedirectToAction("MyRequests");

        }
    }
}
