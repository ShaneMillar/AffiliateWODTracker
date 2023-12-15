using AffiliateWODTracker.Core.Models;
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
            CreateMap<MemberEntity, Member>();
            CreateMap<Member, MemberEntity>();
            CreateMap<WODModel, WODEntity>();

            // Add other mappings here
        }

    }

}
