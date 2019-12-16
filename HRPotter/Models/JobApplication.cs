using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPotter.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Creator")]
        public virtual int? CreatorId { get; set; }
        public virtual User Creator { get; set; }


        public virtual int JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9]+(\\.[a-zA-Z0-9]+)*)+@[a-zA-Z0-9]+(\\.[A-Za-z]+)+$", ErrorMessage = "Input should be valid e-mail")]
        public string Email { get; set; }
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Phone number should only contain 9 digits")]
        public string Phone { get; set; }

        public string CvUrl { get; set; }

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
