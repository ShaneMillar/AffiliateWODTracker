using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IAffiliateManager
    {
        Task<AffiliateViewModel> GetAffiliateByUserId(string userId);

        Task CreateAffiliate(AffiliateEntity affiliate);

        Task DeleteAffiliate(int affiliateId);
    }
}
