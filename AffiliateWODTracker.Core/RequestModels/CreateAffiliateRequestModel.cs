using System.ComponentModel.DataAnnotations;

namespace AffiliateWODTracker.Core.RequestModels
{
    public class CreateAffiliateRequestModel
    {
            [Required(ErrorMessage = "Affiliate name is required.")]
            [Display(Name = "Affiliate Name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Affiliate address is required.")]
            [Display(Name = "Affiliate Address")]
            public string Address { get; set; }
    }
}
