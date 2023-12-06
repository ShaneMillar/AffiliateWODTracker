using AffiliateWODTracker.Core.ViewModels;
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
               .Where(m => m.AffiliateId == affiliateId)
               .Join(_context.Status,
                     member => member.StatusId,
                     status => status.StatusId,
                     (member, status) => new { Member = member, Status = status })
               .Where(ms => ms.Status.Name == "Accepted")
               .Select(ms => ms.Member)
               .ToListAsync();

            return members;
        }

        public async Task<IEnumerable<MemberEntity>> GetRequestedMembersByAffiliateId(int affiliateId)
        {
            var members = await _context.Members
               .Where(m => m.AffiliateId == affiliateId)
               .Join(_context.Status,
                     member => member.StatusId,
                     status => status.StatusId,
                     (member, status) => new { Member = member, Status = status })
               .Where(ms => ms.Status.Name == "Pending")
               .Select(ms => ms.Member)
               .ToListAsync();

            return members;
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
    }
}
