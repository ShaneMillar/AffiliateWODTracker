using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Data.DataModels
{
    public class CommentEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int WODId { get; set; }
        public virtual WODEntity WOD { get; set; } // Navigation property for the WOD
        public DateTime DatePosted { get; set; }
    }
}
