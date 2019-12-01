using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Models
{
    public class JobOfferPagingView
    {
        public IEnumerable<JobOffer> Offers { get; set; }
        public int TotalPages { get; set; }
    }
}
