

using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IWODRepository
    {
        Task InsertAsync(WODEntity workout);
        Task<IEnumerable<AffiliateWodsModel>> GetWODsByAffiliateId(int affiliateId);
    }
}
