namespace AffiliateWODTracker.Core.Models
{
    public class WODModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AffiliateId { get; set; }
        public DateTime TimeCap { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }

    }
}
