using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRPotter.Models
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Job tittle")]
        public string JobTitle { get; set; }

        [Required]
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
    }
}
