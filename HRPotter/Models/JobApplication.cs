using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public Uri CvUrl { get; set; }

        [Display(Name = "Student")]
        public bool IsStudent { get; set; }

        public string Description { get; set; }

        public ApplicationStatus Status { get; set; }
    }

    public enum ApplicationStatus
    {
        [Description("To be reviewed")]
        ToBeReviewed = 1,
        Reviewed = 2,
        Approved = 3,
        Rejected = 4
    }

}
