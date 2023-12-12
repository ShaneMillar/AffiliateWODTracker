using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberEntity>> GetAllMembersAssociatedWithAffiliate(int affiliateId);
        Task<IEnumerable<MemberEntity>> GetRequestedMembersByAffiliateId(int affiliateId);
        Task<int> GetActiveMembersCountByAffiliateId(int affiliateId);
        Task<int> GetPendingRequestsCountByAffiliateId(int affiliateId);
        Task<MemberEntity> FindMemberById(int id);
        Task UpdateAsync(MemberEntity member);
        Task DeleteAsync(int id);
        Task InsertAsync(MemberEntity member);
    }
}
