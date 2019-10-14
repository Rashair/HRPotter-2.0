using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRPotter.Models;
using System.IO;

namespace HRPotter.Controllers
{
    public class JobApplicationsController : Controller
    {

        private readonly static List<JobApplication> jobApplications = new List<JobApplication>
        {
            new JobApplication {JobOfferId = 2, FirstName = "Stefan" , LastName = "Johnson" , Email = "johnson@nsa.gov"},
            new JobApplication {JobOfferId = 3, FirstName = "Bogdan" , LastName = "Smith" , Email = "smith@nsa.gov"},
            new JobApplication {JobOfferId = 3, FirstName = "Ambroży" , LastName = "Miller" , Email = "miller@nsa.gov"},
            new JobApplication {JobOfferId = 1, FirstName = "Bogusław" , LastName = "Jones" , Email = "jones@nsa.gov"},
            new JobApplication {JobOfferId = 2, FirstName = "Lech" , LastName = "Wilson" , Email = "wilson@nsa.gov"},
            new JobApplication {JobOfferId = 2, FirstName = "Orfeusz" , LastName = "Williams" , Email = "williams@nsa.gov"}
        };

        public JobApplicationsController()
        {
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

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobApplications/Create
        [HttpPost]
        public IActionResult Create([Bind("Id,JobOfferId,FirstName,LastName,Email,Phone,University,StudySubject,StudiesBeginning,StudiesEnd,IsStudent")] JobApplication jobApplication)
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
            if (id != jobApplication.Id)
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
