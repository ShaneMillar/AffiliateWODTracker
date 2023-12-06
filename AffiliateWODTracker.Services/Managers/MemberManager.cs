using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;
using AutoMapper;

namespace AffiliateWODTracker.Services.Managers
{
    public class MemberManager : IMemberManager
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberManager(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId)
        {
            var members = await _memberRepository.GetAllMembersAssociatedWithAffiliate(affiliateId);

            if (members.Any())
            {
                return _mapper.Map<List<MemberViewModel>>(members.ToList());
            }
            return null;
        }

        public async Task<List<MemberViewModel>> GetRequestedMembersByAffiliateId(int affiliateId)
        {
            var members = await _memberRepository.GetRequestedMembersByAffiliateId(affiliateId);

            if (members.Any())
            {
                return _mapper.Map<List<MemberViewModel>>(members.ToList());
            }
            return null;
        }

        public async Task DeleteMember(int memberId)
        {
            await _memberRepository.DeleteAsync(memberId);
        }
    }
}
