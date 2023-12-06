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
            return await _context.Members.Where(m => m.AffiliateId == affiliateId).ToListAsync();
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
