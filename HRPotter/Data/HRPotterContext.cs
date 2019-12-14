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
                    CreatorId = 2,
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
                    CreatorId = 2,
                    JobOfferId = 3,
                    FirstName = "Bogdan",
                    LastName = "Smith",
                    Email = "smith@nsa.gov",
                    Status = ApplicationStatus.ToBeReviewed
                },
                new JobApplication
                {
                    Id = 3,
                    CreatorId = 2,
                    JobOfferId = 5,
                    FirstName = "Ambroży",
                    LastName = "Miller",
                    Email = "miller@nsa.gov",
                    IsStudent = true,
                    Status = ApplicationStatus.ToBeReviewed,
                    CvUrl = "TAiJF_Cwiczenie_04.pdf"
                },
                new JobApplication
                {
                    Id = 4,
                    CreatorId = 7,
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
                    CreatorId = 7,
                    JobOfferId = 1,
                    FirstName = "Lech",
                    LastName = "Wilson",
                    Email = "wilson@nsa.gov",
                    Status = ApplicationStatus.ToBeReviewed
                },
                new JobApplication
                {
                    Id = 6,
                    CreatorId = 7,
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
                    CreatorId = 6,
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
                    CreatorId = 4,
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
                    CreatorId = 6,
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
                    CreatorId = 4,
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
                    CreatorId = 4,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                    CreatorId = 6,
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
                new Role { Id = 2, Name = "HR" },
                new Role { Id = 3, Name = "Admin" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, B2CKey = "c3513236-6bcd-4443-bcc3-f39edb2a372b", Name = "admin", RoleId = 3 },
                new User { Id = 2, B2CKey = "48243631-2f99-4553-88f5-8dd9a07a92e3", Name = "testUser", RoleId = 1 },
                new User { Id = 4, B2CKey = "701dcb7e-0a16-46f5-a846-d5a06cbd774c", Name = "stefan", RoleId = 2 },
                new User { Id = 6, B2CKey = "6fa35afc-2051-424b-9d4d-b4933c023081", Name = "hr1", RoleId = 2 },
                new User { Id = 7, B2CKey = "879cc927-1809-47a6-a0c2-ee4f76815b15", Name = "test1", RoleId = 1 }
            );
        }
    }
}
