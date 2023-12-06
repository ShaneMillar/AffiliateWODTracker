using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;
using AutoMapper;

namespace AffiliateWODTracker.Services.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<MemberEntity, MemberViewModel>();
            CreateMap<AffiliateEntity, AffiliateViewModel>();
            // Add other mappings here
        }

    }

}
