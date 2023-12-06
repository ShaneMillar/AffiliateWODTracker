using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IMemberManager
    {
        Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId);

        Task<List<MemberViewModel>> GetRequestedMembersByAffiliateId(int affiliateId);

        Task UpdateMemberToAccepted(int memberId);
        Task DeleteMember(int memberId);
    }
}
