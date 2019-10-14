using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int JobOfferId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        public string University { get; set; }
        [Display(Name = "Study subject")]
        public string StudySubject { get; set; }
        [Display(Name = "Start date")]
        public DateTime StudiesStart { get; set; }
        [Display(Name = "End date")]
        public DateTime StudiesEnd { get; set; }
        [Display(Name = "Student")]
        public bool IsStudent { get; set; }
    }
}
