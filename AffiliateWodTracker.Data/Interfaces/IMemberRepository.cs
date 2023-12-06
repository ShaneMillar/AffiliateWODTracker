using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberEntity>> GetAllMembersAssociatedWithAffiliate(int affiliateId);
        Task DeleteAsync(int id);
    }
}
