using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;

namespace AffiliateWODTracker.Services.Managers
{
    public class AffiliateManager : IAffiliateManager
    {
        private readonly IAffiliateRepository _affiliateRepository;


        public AffiliateManager(IAffiliateRepository affiliateRepository)
        {
            _affiliateRepository = affiliateRepository;
        }

        public async Task<AffiliateViewModel> GetAffiliateByUserId(string userId)
        {
            var affiliate = await _affiliateRepository.GetAffiliateByUserIdAsync(userId);

            return affiliate;
        }

        public async Task CreateAffiliate(AffiliateEntity affiliate)
        {
           await _affiliateRepository.InsertAsync(affiliate);
        }

        public async Task DeleteAffiliate(int affiliateId)
        {
            await _affiliateRepository.DeleteAsync(affiliateId);
        }

        //ADD Insert Affiliate

    }
}
