using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRPotter.Models
{
    public class HRPotterContext : DbContext
    {
        public HRPotterContext (DbContextOptions<HRPotterContext> options)
            : base(options)
        {
        }

        public DbSet<HRPotter.Models.JobApplication> JobApplication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");
        }
    }
}
