using AffiliateWODTracker.Core.ViewModels;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IMemberManager
    {
        Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId);

        Task<List<MemberViewModel>> GetRequestedMembersByAffiliateId(int affiliateId);
        Task DeleteMember(int memberId);
    }
}
