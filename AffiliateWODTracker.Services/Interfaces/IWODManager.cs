using AffiliateWODTracker.Core.Models;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IWODManager
    {
        Task CreateWOD(WODModel workout);
    }
}
