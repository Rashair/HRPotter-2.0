using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Models
{
    public class Company
    {
        public static List<Company> companies = new List<Company> {
            new Company{Id = 1, Name = "Microsoft"},
            new Company{Id = 2, Name = "Apple"},
            new Company{Id = 3, Name = "Warsaw University of Technology"}
        };


        public int Id { get; set; }

        public string Name { get; set; }
    }
}
