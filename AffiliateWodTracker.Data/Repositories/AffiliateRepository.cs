using AffiliateWODTracker.Core.Models;
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

        public async Task<IEnumerable<AffiliateEntity>> GetAllAsync()
        {
            return await _context.Affiliates.ToListAsync();

        }

        public async Task<AffiliateEntity> GetAffiliateByUserIdAsync(string userId)
        {
            // Attempt to retrieve the affiliate associated with the user
            return await _context.Affiliates
                .Include(a => a.Owner)
                .Where(a => a.Owner.Id == userId)
                .FirstOrDefaultAsync();
        }


        public async Task<Affiliate> GetByIdAsync(int id)
        {
          var x = await _context.Affiliates.FindAsync(id);
            return new Affiliate();
        }

        public async Task InsertAsync(AffiliateEntity affiliate)
        {
            await _context.Affiliates.AddAsync(affiliate);
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
            var affilate = await _context.Affiliates.FindAsync(id);
            if (affilate != null)
            {
                _context.Affiliates.Remove(affilate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
