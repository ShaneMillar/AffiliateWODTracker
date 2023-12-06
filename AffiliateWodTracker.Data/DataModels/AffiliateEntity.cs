using AffiliateWODTracker.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Data.DataModels
{
    public class AffiliateEntity
    {
        [Key]
        public int AffiliateId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string OwnerId { get; set; }
        public virtual ICollection<MemberEntity> Members { get; set; } // Navigation property for WODs

        public virtual OwnerEntity Owner { get; set; }

    }
}
