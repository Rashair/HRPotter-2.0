using HRPotter.Controllers;
using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HRPotter.UnitTests
{
    [TestFixture]
    public class JobOffersControllerTests
    {
        DbContextOptions<HRPotterContext> options;
        private HRPotterContext context;
        private JobOffersController controller;

        public readonly static List<JobOffer> jobOffers = new List<JobOffer>
        {
            new JobOffer {Id = 1, JobTitle = "Backend Developer", CompanyId = 1 , Location = "Warsaw" , SalaryTo = 15000,
                Description=String.Join(' ',Enumerable.Repeat("lorem ipsum", 10))},
            new JobOffer {Id = 2, JobTitle = "Frontend Developer", CompanyId = 1 , Location = "Warsaw" , SalaryFrom = 10000,
                Description=String.Join(' ',Enumerable.Repeat("lorem ipsum", 10))},
            new JobOffer {Id = 3, JobTitle = "Manager", CompanyId = 2 , Location = "New York" , SalaryFrom = 15000, SalaryTo = 25000},
            new JobOffer {Id = 4, JobTitle = "Teacher", CompanyId = 3 , Location = "Warsaw" , SalaryFrom = 10000,
                SalaryTo = 15000, Description=String.Join(' ',Enumerable.Repeat("lorem ipsum", 10))},
            new JobOffer {Id = 5, JobTitle = "Cook", CompanyId = 4 , Location = "Warsaw" , SalaryFrom = 10000, SalaryTo = 15000,
                Description=String.Join(' ',Enumerable.Repeat("lorem ipsum", 10))},
        };

        private readonly static List<JobApplication> jobApplications = new List<JobApplication>
        {
            new JobApplication {JobOfferId = 2, FirstName = "Stefan" , LastName = "Johnson" , Email = "johnson@nsa.gov"},
            new JobApplication {JobOfferId = 3, FirstName = "Bogdan" , LastName = "Smith" , Email = "smith@nsa.gov"},
            new JobApplication {JobOfferId = 3, FirstName = "Ambroży" , LastName = "Miller" , Email = "miller@nsa.gov"},
            new JobApplication {JobOfferId = 1, FirstName = "Bogusław" , LastName = "Jones" , Email = "jones@nsa.gov"},
            new JobApplication {JobOfferId = 2, FirstName = "Lech" , LastName = "Wilson" , Email = "wilson@nsa.gov"},
            new JobApplication {JobOfferId = 2, FirstName = "Orfeusz" , LastName = "Williams" , Email = "williams@nsa.gov"}
        };


        public readonly static List<Company> companies = new List<Company>
        {
            new Company {Id = 1, Name = "Microsoft"},
            new Company {Id = 2, Name = "Apple"},
            new Company {Id = 3, Name = "EBR-IT"},
            new Company {Id = 4, Name = "Google"}
        };

        public JobOffersControllerTests()
        {
            options = new DbContextOptionsBuilder<HRPotterContext>()
                .UseInMemoryDatabase(databaseName: "HRPotterDatabase").Options;

            context = new HRPotterContext(options);
            context.JobOffers.Add(jobOffers[0]);
            context.JobOffers.Add(jobOffers[1]);
            context.JobApplications.Add(jobApplications[3]);
            context.Companies.Add(companies[0]);
            context.SaveChanges();

            controller = new JobOffersController(context);
        }

        [SetUp]
        public void Setup()
        {

        }

        // Index
        [Test]
        [Timeout(5000)]
        public void Index_WhenItsCalled_ShouldReturnView()
        {
            // Act
            IActionResult result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.AreEqual(viewResult.StatusCode, StatusCodes.Status200OK);
        }

        // AplicationsCount
        [Test]
        [Timeout(5000)]
        public void ApplicationsCountForOfferId_WhenItsCalled_ShouldReturnNumber()
        {
            // Arrange
            int id = jobOffers[0].Id;

            // Act
            var result = controller.ApplicationsCount(id).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var objResult = (ObjectResult)result;
            int num = (int)objResult.Value;
            Assert.That(num == jobOffers[0].JobApplications.Count);
        }

        [Test]
        [Timeout(5000)]
        public void ApplicationsCountForInvalidOfferId_WhenItsCalled_ShouldReturnNotFound()
        {
            // Arrange
            int id = 0;

            // Act
            var result = controller.ApplicationsCount(id).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        [Timeout(5000)]
        public void EditForInvalidOfferId_WhenItsCalled_ShouldThrowException()
        {
            // Arrange
            int id = -1;
            JobOffer offer = new JobOffer { Id = id };

            // Act and Assert
            Assert.Throws<AggregateException>(() => { var result = controller.Edit(offer).Result; });
        }
    }
}