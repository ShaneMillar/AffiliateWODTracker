namespace AffiliateWODTracker.Core.ViewModels
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AffiliateId { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
