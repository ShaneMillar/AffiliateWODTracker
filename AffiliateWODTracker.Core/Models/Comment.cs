namespace AffiliateWODTracker.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } // Navigation property for the User
        public int WODId { get; set; }
        public virtual WODModel WOD { get; set; } // Navigation property for the WOD
        public DateTime DatePosted { get; set; }
    }
}
