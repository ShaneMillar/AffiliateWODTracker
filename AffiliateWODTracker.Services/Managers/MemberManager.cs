using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.Interfaces;
using AffiliateWODTracker.Services.Interfaces;

namespace AffiliateWODTracker.Services.Managers
{
    public class MemberManager : IMemberManager
    {
        private readonly IMemberRepository _memberRepository;

        public MemberManager(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<MemberViewModel>> GetMembersByAffiliateId(int affiliateId)
        {
            var members = await _memberRepository.GetAllMembersAssociatedWithAffiliate(affiliateId);
            if (members == null)
            {
                return null;
            }
            return members.ToList();
        }
    }
}
