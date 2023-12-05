namespace AffiliateWODTracker.Data.DataModels
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int WODId { get; set; }
        public virtual WODEntity WOD { get; set; } // Navigation property for the WOD
        public DateTime DatePosted { get; set; }
    }
}
