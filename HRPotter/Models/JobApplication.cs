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
        public Person PersonData { get; set; }
        public Educaction EducationData { get; set; }
    }
}
