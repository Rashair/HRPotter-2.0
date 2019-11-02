using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? ValidUntil { get; set; }

        public string Description { get; set; }
    }
}
