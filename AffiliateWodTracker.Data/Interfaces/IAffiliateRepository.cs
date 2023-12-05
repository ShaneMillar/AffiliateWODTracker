﻿
using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;

namespace AffiliateWODTracker.Data.Interfaces
{
    public interface IAffiliateRepository
    {
        Task<IEnumerable<Affiliate>> GetAllAsync();
        Task<Affiliate> GetByIdAsync(int id);
        Task<AffiliateViewModel> GetAffiliateByUserIdAsync(string userId);
        Task InsertAsync(Affiliate affiliate);
        Task UpdateAsync(Affiliate affiliate);
        Task DeleteAsync(int id);
    }
}
