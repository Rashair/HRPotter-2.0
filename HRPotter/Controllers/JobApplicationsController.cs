using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Controllers
{
    public class JobApplicationsController : Controller
    {
        private HRPotterContext _context;
        public JobApplicationsController(HRPotterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                List<JobApplication> applications = await _context.JobApplications.Include(x => x.JobOffer).ToListAsync();
                return View(applications);
            }

            List<JobApplication> searchResult = await _context.JobApplications.Include(x => x.JobOffer).
                Where(app => app.JobOffer.JobTitle.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).
                ToListAsync();
            return View(searchResult);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            var app = await _context.JobApplications.Include(x => x.JobOffer).FirstOrDefaultAsync(o => o.Id == id);
            if (app == null)
            {
                return NotFound($"Application with corresponding id was not found: {id}");
            }

            return View(app);
        }

        public async Task<IActionResult> DetailsHR(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            var jobApplication = await _context.JobApplications.Include(x => x.JobOffer).FirstOrDefaultAsync(app => app.Id == id);
            if (jobApplication == null)
            {
                return NotFound($"Application with corresponding id was not found: {id}");
            }

            return View(jobApplication);
        }


        // POST: JobApplications/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int? id, int? status)
        {
            if (id == null || status == null || !Enum.IsDefined(typeof(ApplicationStatus), status.Value))
            {
                return BadRequest();
            }


            JobApplication app = await _context.JobApplications.FirstOrDefaultAsync(app => app.Id == id);
            if(app == null)
            {
                return NotFound();
            }
            app.Status = (ApplicationStatus)status.Value;
            _context.Update(app);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DetailsHR), new { id = id.Value });
        }


        // GET: JobApplications/Add/1
        [HttpGet]
        public async Task<IActionResult> Create(int? offerId)
        {
            if (offerId == null)
            {
                return BadRequest("Id cannot be null");
            }

            JobOffer offer = await _context.JobOffers.FirstOrDefaultAsync(jobOffer => jobOffer.Id == offerId.Value);
            if (offer == null)
            {
                return NotFound($"Offer with corresponding id was not found: {offerId}");
            }

            JobApplication jobApplication = new JobApplication
            {
                JobOfferId = offerId.Value,
                JobOffer = offer
            };

            return View(jobApplication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobApplication app = new JobApplication
            {
                JobOfferId = model.JobOfferId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                CvUrl = model.CvUrl,
                IsStudent = model.IsStudent,
                Description = model.Description,
                Status = ApplicationStatus.ToBeReviewed
            };

            await _context.JobApplications.AddAsync(app);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            var jobApplication = await _context.JobApplications.Include(x => x.JobOffer).
                FirstOrDefaultAsync(app => app.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobApplication app = await _context.JobApplications.FirstOrDefaultAsync(app => app.Id == model.Id);

            app.FirstName = model.FirstName;
            app.LastName = model.LastName;
            app.Email = model.Email;
            app.Phone = model.Phone;
            app.CvUrl = model.CvUrl;
            app.IsStudent = model.IsStudent;
            app.Description = model.Description;
            _context.Update(app);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.Id });
        }

        // POST: JobApplications/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            _context.Remove(new JobApplication { Id = id.Value });
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
