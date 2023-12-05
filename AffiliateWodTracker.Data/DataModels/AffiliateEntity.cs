using AffiliateWODTracker.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace AffiliateWODTracker.Data.DataModels
{
    public class AffiliateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<MemberEntity> Members { get; set; } // Navigation property for WODs

        public virtual OwnerEntity Owner { get; set; }

    }
}
