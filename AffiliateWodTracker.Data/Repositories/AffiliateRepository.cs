using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AffiliateWODTracker.Data.Repositories
{
    public class AffiliateRepository : IAffiliateRepository
    {
        private readonly ApplicationDataContext _context;

        public AffiliateRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Affiliate>> GetAllAsync()
        {
            var affiliates = await _context.Affiliates.ToListAsync();

            return affiliates.Select(a => new Affiliate
            {
                Id = a.Id,
                Name = a.Name,
                // Map other properties as needed
            }).ToList();

        }

        public async Task<AffiliateViewModel> GetAffiliateByUserIdAsync(string userId)
        {
            // Attempt to retrieve the affiliate associated with the user
            var affiliate = await _context.Affiliates
                .Include(a => a.Owner)
                .Where(a => a.Owner.Id == userId)
                .FirstOrDefaultAsync();

            if (affiliate == null)
            {
                return null; 
            }

            // If not null, map the entity to the model
            return new AffiliateViewModel
            {
                Name = affiliate.Name,
                Address = affiliate.Address
            };
        }


        public async Task<Affiliate> GetByIdAsync(int id)
        {
          var x = await _context.Affiliates.FindAsync(id);
            return new Affiliate();
        }

        public async Task InsertAsync(Affiliate affiliate)
        {
            var dto = new AffiliateEntity();
            await _context.Affiliates.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Affiliate affiliate)
        {

            var dto = new AffiliateEntity();
            _context.Affiliates.Update(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Affiliates.FindAsync(id);
            if (user != null)
            {
                _context.Affiliates.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
