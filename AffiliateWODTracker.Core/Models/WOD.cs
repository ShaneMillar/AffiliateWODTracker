namespace AffiliateWODTracker.Core.Models
{
    public class WOD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AffiliateId { get; set; }
        public DateTime TimeCap { get; set; }
        public virtual Affiliate Affiliate { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
