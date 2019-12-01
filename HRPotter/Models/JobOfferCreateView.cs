using System.Collections.Generic;

namespace HRPotter.Models
{
    public class JobOfferCreateView : JobOffer
    {
        public JobOfferCreateView() { }

        public JobOfferCreateView(JobOffer offer)
        {
            Id = offer.Id;
            JobTitle = offer.JobTitle;
            CompanyId = offer.CompanyId;
            Company = offer.Company;
            Location = offer.Location;
            SalaryFrom = offer.SalaryFrom;
            SalaryTo = offer.SalaryTo;
            Created = offer.Created;
            ValidUntil = offer.ValidUntil;
            Description = offer.Description;
        }


        public IEnumerable<Company> Companies { get; set; }
    }
}
