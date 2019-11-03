using HRPotter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Data
{
    public class HRPotterContext : DbContext
    {
        public HRPotterContext(DbContextOptions<HRPotterContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<Company> Companies { get; set; }
    }
}
