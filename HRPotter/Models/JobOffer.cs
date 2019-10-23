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
        [Display(Name ="Job tittle")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public int SalaryFrom { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public int SalaryTo { get; set; }

        public string Description { get; set; }
    }
}
