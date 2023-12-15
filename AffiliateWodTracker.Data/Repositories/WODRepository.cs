using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Data.DataModels;
using AffiliateWODTracker.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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


        public async Task<IEnumerable<AffiliateWodsModel>> GetWODsByAffiliateId(int affiliateId)
        {
            var wods = await _context.WODs
                .Where(wod => wod.AffiliateId == affiliateId)
                .Join(_context.Members,
                      wod => wod.UserId,
                      member => member.UserId,
                      (wod, member) => new AffiliateWodsModel
                      {
                          Title = wod.Title,
                          Description = wod.Description,
                          CreatedByUser = member.FirstName + " " + member.LastName,
                          CreatedDate = wod.CreatedDate
                      })
                .ToListAsync();

            return wods;
        }
    }
}
