using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotter.Controllers
{
    [Route("[controller]")]
    public class JobApplicationsController : Controller
    {
        private HRPotterContext _context;
        public JobApplicationsController(HRPotterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Main page
        /// </summary>
        /// <returns> Job applications list</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplications.Include(x => x.JobOffer).ToListAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationsTable([FromQuery(Name = "query")] string searchString)
        {
            List<JobApplication> applications;
            if (string.IsNullOrEmpty(searchString))
            {
                applications = await _context.JobApplications.Include(x => x.JobOffer).ToListAsync();
            }
            else
            {
                applications = await _context.JobApplications.Include(x => x.JobOffer).
                    Where(app => app.JobOffer.JobTitle.Contains(searchString)).
                    ToListAsync();
            }

            return PartialView("_ApplicationsTable", applications);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpGet]
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


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int? id, int? status)
        {
            if (id == null || status == null || !Enum.IsDefined(typeof(ApplicationStatus), status.Value))
            {
                return BadRequest();
            }

            JobApplication app = await _context.JobApplications.FirstOrDefaultAsync(app => app.Id == id);
            if (app == null)
            {
                return NotFound();
            }

            app.Status = (ApplicationStatus)status.Value;
            _context.Update(app);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DetailsHR), "JobOffers", new { id = app.JobOfferId });
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpGet]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]/{id}")]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> ApplicationsForOffer(int? id, [FromQuery(Name = "query")] string searchString)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            List<JobApplication> result;
            if (String.IsNullOrEmpty(searchString))
            {
                result = await _context.JobApplications.Where(app => app.JobOfferId == id).ToListAsync();
            }
            else
            {
                result = await _context.JobApplications.Where(app => app.JobOfferId == id &&
                   (app.FirstName.Contains(searchString) || app.LastName.Contains(searchString))).
                   ToListAsync();
            }

            return PartialView("_ApplicationsTable", result);
        }
    }
}
