using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;
using AutoMapper;

namespace AffiliateWODTracker.Services.Managers
{
    public class AffiliateManager : IAffiliateManager
    {
        private readonly IAffiliateRepository _affiliateRepository;
        private readonly IMapper _mapper;


        public AffiliateManager(IAffiliateRepository affiliateRepository, IMapper mapper)
        {
            _affiliateRepository = affiliateRepository;
            _mapper = mapper;

        }

        public async Task<List<AffiliateViewModel>> GetAllAffiliates()
        {
            var affiliates = await _affiliateRepository.GetAllAsync();

            if (affiliates.Any())
            {
                return _mapper.Map<List<AffiliateViewModel>>(affiliates.ToList());
            }

            return null;
        }

        public async Task<AffiliateViewModel> GetAffiliateByUserId(string userId)
        {
            var affiliate = await _affiliateRepository.GetAffiliateByUserIdAsync(userId);

            if(affiliate != null)
            {
                return _mapper.Map<AffiliateViewModel>(affiliate);
            }

            return null;
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
