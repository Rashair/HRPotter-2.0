using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Models
{
    public class JobApplicationModel
    {
        public Person PersonData { get; set; }
        public Educaction EducationData { get; set; }

        public class Person
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        public class Educaction
        {
            public string University { get; set; }
            public string StudySubject { get; set; }
            public DateTime StudiesBeginning { get; set; }
            public DateTime StudiesEnd { get; set; }
            public bool IsStudent { get; set; }
        }
    }
}
