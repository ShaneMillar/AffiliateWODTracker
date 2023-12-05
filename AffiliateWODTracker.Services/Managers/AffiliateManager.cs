using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //ADD Insert Affiliate
     
    }
}
