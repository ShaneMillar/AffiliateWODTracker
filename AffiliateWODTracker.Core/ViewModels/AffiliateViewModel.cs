namespace AffiliateWODTracker.Core.ViewModels
{
    public class AffiliateViewModel
    {
        public int AffiliateId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ActiveMembersCount { get; set; }
        public int PendingRequestsCount { get; set; }
    }
}
