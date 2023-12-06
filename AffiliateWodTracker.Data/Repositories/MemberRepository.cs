using AffiliateWODTracker.Core.ViewModels;
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

        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAssociatedWithAffiliate(int affiliateId)
        {
            var members = await _context.Members.Where(m => m.AffiliateId == affiliateId).ToListAsync();

            if (members.Any())
            {
                return members.Select(m => new MemberViewModel());
            }

            return null;
        }
    }
}
