using System;
using System.ComponentModel.DataAnnotations;

namespace HRPotter.Models
{
    public class Educaction
    {
        [Key]
        public int Id { get; set; }
        public string University { get; set; }
        public string StudySubject { get; set; }
        public DateTime StudiesBeginning { get; set; }
        public DateTime StudiesEnd { get; set; }
        public bool IsStudent { get; set; }
    }
}