using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IMemberManager
    {
        Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId);
        Task<List<MemberViewModel>> GetRequestedMembersByAffiliateId(int affiliateId);
        Task<int> GetActiveMembersCountByAffiliateId(int affiliateId);
        Task<int> GetPendingRequestsCountByAffiliateId(int affiliateId);
        Task<Member> GetMemberByUserId(string userId);
        Task UpdateMemberToAccepted(int memberId);
        Task UpdateMemberToRejected(int memberId);
        Task UpdateMemberToPending(int memberId);
        Task DeleteMember(int memberId);
        Task CreateMember(Core.Models.Member member);
    }
}
