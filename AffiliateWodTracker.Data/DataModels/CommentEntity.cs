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
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public virtual WODEntity WOD { get; set; } 


    }
}
