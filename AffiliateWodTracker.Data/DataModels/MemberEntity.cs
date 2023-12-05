namespace AffiliateWODTracker.Data.DataModels
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AffiliateId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual AffiliateEntity Affiliate { get; set; }

    }
}
