
using AffiliateWODTracker.Core.Models;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IAffiliateRepository
    {
        Task<IEnumerable<Affiliate>> GetAllAsync();
        Task<Affiliate> GetByIdAsync(int id);
        Task InsertAsync(Affiliate affiliate);
        Task UpdateAsync(Affiliate affiliate);
        Task DeleteAsync(int id);
    }
}
