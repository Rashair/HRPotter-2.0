using HRPotter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HRPotter.Data
{
    public class HRPotterContext : DbContext
    {
        public HRPotterContext(DbContextOptions<HRPotterContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobApplication>().HasIndex(x => x.JobOfferId);
            modelBuilder.Entity<JobApplication>().HasIndex(x => x.LastName);
            modelBuilder.Entity<JobOffer>().HasIndex(x => x.JobTitle);

            modelBuilder.Entity<User>().HasIndex(x => x.B2CKey).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();

            // Data
            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = 1,
                    JobOfferId = 2,
                    FirstName = "Stefan",
                    LastName = "Johnson",
                    Email = "johnson@nsa.gov",
                    Status = ApplicationStatus.ToBeReviewed,
                    Description = String.Join(' ', Enumerable.Repeat("lorem ipsum", 5)),
                },
                new JobApplication
                {
                    Id = 2,
                    JobOfferId = 3,
                    FirstName = "Bogdan",
                    LastName = "Smith",
                    Email = "smith@nsa.gov",
                    Status = ApplicationStatus.ToBeReviewed
                },
                new JobApplication
                {
                    Id = 3,
                    JobOfferId = 5,
                    FirstName = "Ambroży",
                    LastName = "Miller",
                    Email = "miller@nsa.gov",
                    IsStudent = true,
                    Status = ApplicationStatus.ToBeReviewed,
                    CvUrl = new Uri("https://www.google.com")
                },
                new JobApplication
                {
                    Id = 4,
                    JobOfferId = 6,
                    FirstName = "Bogusław",
                    LastName = "Jones",
                    Email = "jones@nsa.gov",
                    Phone = "555444333",
                    Status = ApplicationStatus.ToBeReviewed
                },
                new JobApplication
                {
                    Id = 5,
                    JobOfferId = 1,
                    FirstName = "Lech",
                    LastName = "Wilson",
                    Email = "wilson@nsa.gov",
                    Status = ApplicationStatus.ToBeReviewed
                },
                new JobApplication
                {
                    Id = 6,
                    JobOfferId = 2,
                    FirstName = "Orfeusz",
                    LastName = "Williams",
                    Email = "williams@nsa.gov",
                    Phone = "222333111",
                    Status = ApplicationStatus.ToBeReviewed
                }
            );

            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = 1,
                    JobTitle = "Backend Developer",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Warsaw",
                    SalaryTo = 15000,
                    Description = String.Join(' ', Enumerable.Repeat("lorem ipsum", 10))
                },
                new JobOffer
                {
                    Id = 2,
                    JobTitle = "Frontend Developer",
                    CompanyId = 2,
                    Created = DateTime.Now,
                    ValidUntil = DateTime.Now.AddDays(10),
                    Location = "Warsaw",
                    SalaryFrom = 10000,
                    Description = String.Join(' ', Enumerable.Repeat("lorem ipsum", 10))
                },
                new JobOffer
                {
                    Id = 3,
                    JobTitle = "Manager",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    ValidUntil = DateTime.Now.AddDays(5),
                    Location = "New York",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 4,
                    JobTitle = "Teacher",
                    CompanyId = 3,
                    Created = DateTime.Now,
                    Location = "Paris",
                    SalaryFrom = 10000,
                    SalaryTo = 15000,
                    Description = String.Join(' ', Enumerable.Repeat("lorem ipsum", 10))
                },
                new JobOffer
                {
                    Id = 5,
                    JobTitle = "Cook",
                    CompanyId = 4,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 10000,
                    SalaryTo = 15000,
                    Description = String.Join(' ', Enumerable.Repeat("lorem ipsum", 10))
                },
                new JobOffer
                {
                    Id = 6,
                    JobTitle = "Manager",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 7,
                    JobTitle = "Tst1",
                    CompanyId = 2,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 4000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 8,
                    JobTitle = "Tst2",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 9,
                    JobTitle = "Tst3",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 10,
                    JobTitle = "Tst4",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 11,
                    JobTitle = "Tst5",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 12,
                    JobTitle = "Tst6",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 13,
                    JobTitle = "Tst7",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 14,
                    JobTitle = "Tst8",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                },
                new JobOffer
                {
                    Id = 15,
                    JobTitle = "Tst9",
                    CompanyId = 1,
                    Created = DateTime.Now,
                    Location = "Venice",
                    SalaryFrom = 15000,
                    SalaryTo = 25000
                }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Microsoft" },
                new Company { Id = 2, Name = "Apple" },
                new Company { Id = 3, Name = "Google" },
                new Company { Id = 4, Name = "EBR-IT" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "HRUser" },
                new Role { Id = 3, Name = "Admin" }
            );
        }
    }
}
