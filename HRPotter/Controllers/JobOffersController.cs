using HRPotter.Authorization;
using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRPotter.Controllers
{
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Route("/[controller]")]
    [Authorize(Roles = "User,HR")]
    public class JobOffersController : Controller
    {
        private readonly HRPotterContext _context;

        public JobOffersController(HRPotterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Main page
        /// </summary>
        /// <returns> Job offers list view </returns>
        [Route("[action]")]
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            if (User.GetRole() == "HR")
            {
                return View("IndexHR", null);
            }

            return View();
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetOffersTable(int pageNo = 1, int pageSize = 4, string searchString = "")
        {
            JobOfferPagingView result;
            try
            {
                result = await GetOffersPage(pageNo, pageSize, searchString);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }

            return PartialView("_OffersTable", result);
        }

        private async Task<JobOfferPagingView> GetOffersPage(int pageNo = 1, int pageSize = 4, string searchString = "")
        {
            if (pageNo <= 0 || pageSize < 1)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<JobOffer> record;
            var userRole = User.GetRole();
            if (String.IsNullOrEmpty(searchString))
            {
                if (userRole == "HR")
                {
                    record = await _context.JobOffers.Where(off => off.CreatorId == User.GetId()).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                }
                else
                {
                    record = await _context.JobOffers.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                }
            }
            else
            {
                searchString = searchString.ToLower();
                if (userRole == "HR")
                {
                    record = await _context.JobOffers.Where(x => x.CreatorId == User.GetId() && x.JobTitle.Contains(searchString)).
                        Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                }
                else
                {
                    record = await _context.JobOffers.Where(x => x.JobTitle.Contains(searchString)).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
                }
            }

            JobOfferPagingView offersData = new JobOfferPagingView
            {
                Offers = record,
            };

            return offersData;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetPagingBar")]
        [HttpGet]
        public async Task<IActionResult> GetPagingBar(int pageNo = 1, int pageSize = 4, string searchString = "")
        {
            if (pageNo <= 0 || pageSize < 1)
            {
                return BadRequest();
            }

            int totalRecords;
            int totalPages;
            var userRole = User.GetRole();
            if (String.IsNullOrEmpty(searchString))
            {
                if (userRole == "HR")
                {
                    totalRecords = await _context.JobOffers.Where(off => off.CreatorId == User.GetId()).CountAsync();
                }
                else
                {
                    totalRecords = await _context.JobOffers.CountAsync();
                }
                totalPages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
            }
            else
            {
                searchString = searchString.ToLower();
                if (userRole == "HR")
                {
                    totalRecords = await _context.JobOffers.Where(off => off.CreatorId == User.GetId() && off.JobTitle.ToLower().Contains(searchString)).CountAsync();
                }
                else
                {
                    totalRecords = await _context.JobOffers.Where(x => x.JobTitle.ToLower().Contains(searchString)).CountAsync();
                }
                totalPages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
            }

            return PartialView("_PagingBar", (pageNo, totalPages, totalRecords));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [Authorize(Roles = "HR")]
        [HttpGet]
        public async Task<IActionResult> ApplicationsCount(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var offer = await _context.JobOffers.Include(off => off.JobApplications).FirstOrDefaultAsync(off => off.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer.JobApplications.Count);
        }

        [Route("[action]")]
        [Authorize(Roles = "HR")]
        [HttpGet]
        public async Task<IActionResult> IndexHR()
        {
            return View(await _context.JobOffers.Include(x => x.Company).Where(off => off.CreatorId == User.GetId()).ToListAsync());
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            JobOffer offer = await _context.JobOffers.Include(x => x.Company).FirstOrDefaultAsync(o => o.Id == id);
            if (offer == null)
            {
                return NotFound($"Offer with corresponding id was not found: {id}");
            }

            return View(offer);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [Authorize(Roles = "HR")]
        [HttpGet]
        public async Task<IActionResult> DetailsHR(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            JobOffer offer = await _context.JobOffers.
                Include(x => x.Company).
                Include(x => x.JobApplications).
                FirstOrDefaultAsync(o => o.Id == id);
            if (offer == null)
            {
                return NotFound($"Offer with corresponding id was not found: {id}");
            }

            if (offer.CreatorId != User.GetId())
            {
                return Forbid();
            }

            return View(offer);
        }

        [Route("[action]")]
        [Authorize(Roles = "HR")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new JobOfferCreateView
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [Route("[action]")]
        [Authorize(Roles = "HR")]
        [HttpPost]
        public async Task<ActionResult> Create(JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = await _context.Companies.ToListAsync();
                return View(model);
            }

            JobOffer offer = new JobOffer
            {
                CreatorId = User.GetId(),
                CompanyId = model.CompanyId,
                Description = model.Description,
                JobTitle = model.JobTitle,
                Location = model.Location,
                SalaryFrom = model.SalaryFrom,
                SalaryTo = model.SalaryTo,
                ValidUntil = model.ValidUntil,
                Created = DateTime.Now,
            };

            await _context.JobOffers.AddAsync(offer);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexHR");
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [Authorize(Roles = "HR")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            JobOffer offer = await _context.JobOffers.FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return NotFound($"Offer with corresponding id was not found: {id}");
            }

            if (User.GetId() != offer.CreatorId)
            {
                return Forbid();
            }

            var createView = new JobOfferCreateView(offer)
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(createView);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        [Route("[action]/{id}")]
        [Authorize(Roles = "HR")]
        [HttpPost]
        public async Task<ActionResult> Edit(JobOffer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobOffer offer = await _context.JobOffers.FirstOrDefaultAsync(o => o.Id == model.Id);
            if (offer == null)
            {
                return BadRequest();
            }

            if (User.GetId() != offer.CreatorId)
            {
                return Forbid();
            }

            offer.JobTitle = model.JobTitle;
            offer.Description = model.Description;
            offer.CompanyId = model.CompanyId;
            offer.Location = model.Location;
            offer.SalaryFrom = model.SalaryFrom;
            offer.SalaryTo = model.SalaryTo;
            offer.ValidUntil = model.ValidUntil;
            _context.Update(offer);
            await _context.SaveChangesAsync();

            return RedirectToAction("DetailsHR", new { id = model.Id });
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]/{id}")]
        [Authorize(Roles = "HR")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            int? creatorId = _context.JobOffers.Where(off => off.Id == id).Select(off => off.CreatorId).FirstOrDefault();
            if (!creatorId.HasValue)
            {
                return RedirectToAction("IndexHR");
            }

            if (User.GetId() != creatorId)
            {
                return Forbid();
            }

            _context.Remove(new JobOffer { Id = id.Value });
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexHR");
        }
    }
}
