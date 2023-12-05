using Microsoft.AspNetCore.Identity;

namespace AffiliateWODTracker.Data.DataModels
{
    public class OwnerEntity : IdentityUser
    {
        public int? AffiliateId { get; set; }
        public virtual AffiliateEntity Affiliate { get; set; }
    }
}
