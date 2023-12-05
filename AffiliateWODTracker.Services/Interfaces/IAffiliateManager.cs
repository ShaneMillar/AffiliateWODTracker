using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateWODTracker.Services.Interfaces
{
    public interface IAffiliateManager
    {
        Task<AffiliateViewModel> GetAffiliateByUserId(string userId);
    }
}
