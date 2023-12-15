using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateWODTracker.Core.Models
{
    public class AffiliateWodsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
