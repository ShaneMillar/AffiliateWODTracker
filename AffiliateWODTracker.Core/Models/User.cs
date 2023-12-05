namespace AffiliateWODTracker.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AffiliateId { get; set; }
        public virtual Affiliate Affiliate { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
