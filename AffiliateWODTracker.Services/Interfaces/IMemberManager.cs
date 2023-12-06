using AffiliateWODTracker.Core.ViewModels;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IMemberManager
    {
        Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId);
    }
}
