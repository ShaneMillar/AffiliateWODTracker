using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Data.DataModels
{
    public class StatusEntity
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
