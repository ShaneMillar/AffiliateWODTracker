using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Data.DataModels
{
    public class WODEntity
    {
        [Key]
        public int WodId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AffiliateId { get; set; }
        public DateTime TimeCap { get; set; }
        public DateTime CreatedDate { get; set; }


        //Navigation Properties
        public virtual AffiliateEntity Affiliate { get; set; }

        public virtual ICollection<ScoreEntity> Scores { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}
