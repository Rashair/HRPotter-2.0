using HRPotter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HRPotter.Controllers
{
    public class JobApplicationsController : Controller
    {

        public readonly static List<JobApplication> jobApplications = new List<JobApplication>
        {
            new JobApplication {Id = 0, JobOfferId = 2, FirstName = "Stefan" , LastName = "Johnson" , Email = "johnson@nsa.gov"},
            new JobApplication {Id = 1, JobOfferId = 3, FirstName = "Bogdan" , LastName = "Smith" , Email = "smith@nsa.gov"},
            new JobApplication {Id = 2, JobOfferId = 3, FirstName = "Ambroży" , LastName = "Miller" , Email = "miller@nsa.gov", IsStudent = true},
            new JobApplication {Id = 3, JobOfferId = 1, FirstName = "Bogusław" , LastName = "Jones" , Email = "jones@nsa.gov"},
            new JobApplication {Id = 4, JobOfferId = 2, FirstName = "Lech" , LastName = "Wilson" , Email = "wilson@nsa.gov"},
            new JobApplication {Id = 5, JobOfferId = 2, FirstName = "Orfeusz" , LastName = "Williams" , Email = "williams@nsa.gov"}
        };

        public JobApplicationsController()
        {
            for (int i = 0; i < jobApplications.Count; ++i)
            {

                jobApplications[i].JobOffer = JobOffersController.jobOffers.FirstOrDefault(offer => offer.Id == jobApplications[i].JobOfferId);
            }
        }

        // GET: JobApplications
        public IActionResult Index()
        {
            return View(jobApplications);
        }

        // GET: JobApplications/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = jobApplications.FirstOrDefault(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Add/1
        [HttpGet]
        public IActionResult Add(int? offerId)
        {
            if (offerId == null)
            {
                return NotFound();
            }

            JobOffer offer = JobOffersController.jobOffers.FirstOrDefault(jobOffer => jobOffer.Id == offerId.Value);
            if (offer == null)
            {
                return NotFound();
            }
            JobApplication jobApplication = new JobApplication
            {
                JobOfferId = offerId.Value,
                JobOffer = offer
            };
            return View(jobApplication);
        }

        // POST: JobApplications/Add
        [HttpPost]
        public IActionResult Add([Bind("Id,JobOfferId,FirstName,LastName,Email,Phone,University,StudySubject,StudiesBeginning,StudiesEnd,IsStudent")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                jobApplications.Add(jobApplication);
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = jobApplications.Find(i => i.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,JobOfferId,FirstName,LastName,Email,Phone,University,StudySubject,StudiesBeginning,StudiesEnd,IsStudent")] JobApplication jobApplication)
        {
            if (jobApplication == null || id != jobApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int index = jobApplications.FindIndex(i => i.Id == id);
                jobApplications[index] = jobApplication;
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = jobApplications.FirstOrDefault(m => m.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobApplication = jobApplications.Find(i => i.Id == id);
            jobApplications.Remove(jobApplication);
            return RedirectToAction(nameof(Index));
        }
    }
}
