namespace AffiliateWODTracker.Data.DataModels
{
    public class ScoreEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WODId { get; set; }
        public virtual WODEntity WOD { get; set; } 
        public double TotalReps { get; set; } 
        public DateTime TimeCompleted { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
