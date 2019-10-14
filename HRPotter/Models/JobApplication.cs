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
        public string StudySubject { get; set; }
        public DateTime StudiesBeginning { get; set; }
        public DateTime StudiesEnd { get; set; }
        public bool IsStudent { get; set; }
    }
}
