namespace AffiliateWODTracker.Core.Models
{
    public class Affiliate
    {
        public int AffiliateId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<User> Users { get; set; } // Navigation property for users
        public virtual ICollection<WOD> WODs { get; set; } // Navigation property for WODs
    }
}
