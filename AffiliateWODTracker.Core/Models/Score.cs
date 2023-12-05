namespace AffiliateWODTracker.Core.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } // Navigation property for the User
        public int WODId { get; set; }
        public virtual WOD WOD { get; set; } // Navigation property for the WOD
        public double TotalReps { get; set; } 
        public DateTime TimeCompleted { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
