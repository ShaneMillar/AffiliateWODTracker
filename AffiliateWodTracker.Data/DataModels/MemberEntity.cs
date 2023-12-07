using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Data.DataModels
{
    public class MemberEntity
    {
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AffiliateId { get; set; }
        public int StatusId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }


        // Navigation properties
        public virtual AffiliateEntity Affiliate { get; set; } 

        public virtual StatusEntity Status { get; set; }

    }
}
