using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        public virtual int JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }


        public string University { get; set; }

        [Display(Name = "Study subject")]
        public string StudySubject { get; set; }

        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? StudiesStart { get; set; }

        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? StudiesEnd { get; set; }

        [Display(Name = "Student")]
        public bool IsStudent { get; set; }

        public string Description { get; set; }

        public ApplicationStatus Status { get; set; }
    }

    public enum ApplicationStatus
    {
        [Description("To be reviewed")]
        ToBeReviewed,
        Reviewed,
        Approved,
        Rejected
    }

}
