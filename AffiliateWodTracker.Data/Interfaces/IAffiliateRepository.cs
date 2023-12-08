
using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IAffiliateRepository
    {
        Task<IEnumerable<AffiliateEntity>> GetAllAsync();
        Task<Affiliate> GetByIdAsync(int id);
        Task<AffiliateEntity> GetAffiliateByUserIdAsync(string userId);
        Task InsertAsync(AffiliateEntity affiliate);
        Task UpdateAsync(Affiliate affiliate);
        Task DeleteAsync(int id);
    }
}
