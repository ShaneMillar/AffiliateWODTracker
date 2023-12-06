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
                return members.Select(m => new MemberViewModel { 
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                DateOfBirth = m.DateOfBirth,
                Address = m.Address,
                AffiliateId = affiliateId
                });
            }

            return null;
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
