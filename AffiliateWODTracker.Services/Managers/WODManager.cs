using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;
using AutoMapper;

namespace AffiliateWODTracker.Services.Managers
{
    public class WODManager: IWODManager
    {
        private readonly IWODRepository _wodRepository;
        private readonly IMapper _mapper;

        public WODManager(IWODRepository wodRepository, IMapper mapper)
        {
            _wodRepository = wodRepository;
            _mapper = mapper;

        }

        public async Task CreateWOD(WODModel workout)
        {
            var entity = _mapper.Map<WODEntity>(workout);

            await _wodRepository.InsertAsync(entity);
        }

        public async Task<List<AffiliateWodsModel>> GetWODsByAffiliateId(int affiliateId)
        {
            var workouts = await _wodRepository.GetWODsByAffiliateId(affiliateId);

            if (workouts.Any())
            {
                return workouts.ToList();

            }
            return null;
        }
    }
}
