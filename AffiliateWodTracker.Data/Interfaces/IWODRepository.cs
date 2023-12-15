

using AffiliateWODTracker.Data.DataModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IWODRepository
    {
        Task InsertAsync(WODEntity workout);
    }
}
