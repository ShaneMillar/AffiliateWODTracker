namespace AffiliateWODTracker.Data.DataModels
{
    public class AffiliateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<WODEntity> WODs { get; set; } // Navigation property for WODs
    }
}
