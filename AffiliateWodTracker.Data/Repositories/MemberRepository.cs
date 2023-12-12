using AffiliateWODTracker.Core.Common;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AffiliateWODTracker.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDataContext _context;

        public MemberRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MemberEntity>> GetAllMembersAssociatedWithAffiliate(int affiliateId)
        {
            var members = await _context.Members
               .Where(m => m.AffiliateId == affiliateId && m.Status.Name == LookUpNames.MemberStatus.Accepted)
               .ToListAsync();

            return members;
        }

        public async Task<IEnumerable<MemberEntity>> GetRequestedMembersByAffiliateId(int affiliateId)
        {
            var members = await _context.Members
               .Where(m => m.AffiliateId == affiliateId && m.Status.Name == LookUpNames.MemberStatus.Pending)
               .ToListAsync();

            return members;
        }

        public async Task<int> GetActiveMembersCountByAffiliateId(int affiliateId)
        {
            return await _context.Members
                                 .Where(m => m.AffiliateId == affiliateId && m.Status.Name == LookUpNames.MemberStatus.Accepted)
                                 .CountAsync();
        }

        public async Task<int> GetPendingRequestsCountByAffiliateId(int affiliateId)
        {
            return await _context.Members
                                 .Where(m => m.AffiliateId == affiliateId && m.Status.Name == LookUpNames.MemberStatus.Pending)
                                 .CountAsync();
        }

        public async Task<MemberEntity> FindMemberById(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task UpdateAsync(MemberEntity member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task InsertAsync(MemberEntity member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }
    }
}
