using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPotter.Models
{
    public class JobOffer : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Creator")]
        public virtual int? CreatorId { get; set; }
        public virtual User Creator { get; set; }

        [Required]
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Company field is required")]
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Salary from")]
        [Range(1, 1000000)]
        public int? SalaryFrom { get; set; }

        [Display(Name = "Salary to")]
        [Range(1, 1000000)]
        public int? SalaryTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? ValidUntil { get; set; }

        public string Description { get; set; }

        public List<JobApplication> JobApplications { get; } = new List<JobApplication>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SalaryFrom != null && SalaryTo != null && SalaryFrom > SalaryTo)
            {
                yield return new ValidationResult("Lower bound of salary cannot be greater than upper bound.", new[] { "Salary" });
            }

            if (ValidUntil != null && ValidUntil < DateTime.Now.Date)
            {
                yield return new ValidationResult("Offer expiration date cannot be past date.", new[] { "Expiration date" });
            }
        }
    }
}
