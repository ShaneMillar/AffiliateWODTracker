using Microsoft.AspNetCore.Identity;

namespace AffiliateWODTracker.Data.DataModels
{
    public class OwnerEntity : IdentityUser
    {
        public int? AffiliateId { get; set; }
        public DateTime CreatedDate { get; set; }

        //Navigation Properties
        public virtual AffiliateEntity Affiliate { get; set; }

    }
}
