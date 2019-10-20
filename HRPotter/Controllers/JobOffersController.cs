using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRPotter.Models;

namespace HRPotter.Controllers
{
    public class JobOffersController : Controller
    {
        private readonly static List<JobOffer> jobOffers = new List<JobOffer>
        {
            new JobOffer {Id = 0, JobTitle = "Backend Developer", CompanyName = "Microsoft" , City = "Warsaw" , SalaryFrom = 10000, SalaryTo = 15000},
            new JobOffer {Id = 1, JobTitle = "Frontend Developer", CompanyName = "Microsoft" , City = "Warsaw" , SalaryFrom = 10000, SalaryTo = 15000},
            new JobOffer {Id = 2, JobTitle = "Manager", CompanyName = "Apple" , City = "New York" , SalaryFrom = 15000, SalaryTo = 25000},
            new JobOffer {Id = 3, JobTitle = "Teacher", CompanyName = "Warsaw University of Technology" , City = "Warsaw" , SalaryFrom = 10000, SalaryTo = 15000},
            new JobOffer {Id = 4, JobTitle = "Cook", CompanyName = "Microsoft" , City = "Warsaw" , SalaryFrom = 10000, SalaryTo = 15000},
        };


        public JobOffersController()
        {
        }

        // GET: JobOffers
        public IActionResult Index()
        {
            return View(jobOffers);
        }

        // GET: JobOffers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = jobOffers.FirstOrDefault(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,JobTitle,CompanyName,City,SalaryFrom,SalaryTo,Description")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                jobOffers.Add(jobOffer);
                return RedirectToAction(nameof(Index));
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = jobOffers.Find(jobOffer => jobOffer.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,JobTitle,CompanyName,City,SalaryFrom,SalaryTo,Description")] JobOffer jobOffer)
        {
            if (jobOffer == null || id != jobOffer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int index = jobOffers.FindIndex(i => i.Id == id);
                jobOffers[index] = jobOffer;
                return RedirectToAction(nameof(Index));
            }

            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobOffer = jobOffers.FirstOrDefault(m => m.Id == id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobOffer = jobOffers.Find(jobOffer => jobOffer.Id == id);
            jobOffers.Remove(jobOffer);
            return RedirectToAction(nameof(Index));
        }
    }
}
