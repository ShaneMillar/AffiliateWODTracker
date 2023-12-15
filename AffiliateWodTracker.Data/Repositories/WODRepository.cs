using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;

namespace AffiliateWODTracker.Data.Repositories
{
    public class WODRepository : IWODRepository
    {
        private readonly ApplicationDataContext _context;

        public WODRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(WODEntity workout)
        {
            await _context.WODs.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

    }
}
