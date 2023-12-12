using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;
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

        public async Task<int> GetActiveMembersCountByAffiliateId(int affiliateId)
        {
             return await _memberRepository.GetActiveMembersCountByAffiliateId(affiliateId);
        }

        public async Task<int> GetPendingRequestsCountByAffiliateId(int affiliateId)
        {
            return await _memberRepository.GetPendingRequestsCountByAffiliateId(affiliateId);
        }


        public async Task UpdateMemberToAccepted(int memberId)
        {
            var memberEntity = await _memberRepository.FindMemberById(memberId);

            memberEntity.StatusId = (int)MemberStatus.Accepted;

            await _memberRepository.UpdateAsync(memberEntity);
        }

        public async Task UpdateMemberToRejected(int memberId)
        {
            var memberEntity = await _memberRepository.FindMemberById(memberId);

            memberEntity.StatusId = (int)MemberStatus.Rejected;

            await _memberRepository.UpdateAsync(memberEntity);
        }

        public async Task UpdateMemberToPending(int memberId)
        {
            var memberEntity = await _memberRepository.FindMemberById(memberId);

            memberEntity.StatusId = (int)MemberStatus.Pending;

            await _memberRepository.UpdateAsync(memberEntity);
        }

        public async Task DeleteMember(int memberId)
        {
            await _memberRepository.DeleteAsync(memberId);
        }

        public async Task CreateMember(Core.Models.Member member)
        {
            var memberEntity = _mapper.Map<MemberEntity>(member);

            await _memberRepository.InsertAsync(memberEntity);
        }
    }
}
