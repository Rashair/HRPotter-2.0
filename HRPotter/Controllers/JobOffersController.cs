﻿using HRPotter.Data;
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
    public class JobOffersController : Controller
    {
        private readonly HRPotterContext _context;

        public JobOffersController(HRPotterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetOffersTable([FromQuery(Name = "e")]int author = -1, [FromQuery(Name = "query")] string searchString = "",
            int pageNo = 1, int pageSize = 4)
        {
            if (author == -1)
            {
                return StatusCode(403);
            }


            JobOfferPagingView result;
            try
            {
                result = await GetOffersPage(searchString, pageNo, pageSize);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }

            return PartialView("_OffersTable", (result, author == 1));
        }

        private async Task<JobOfferPagingView> GetOffersPage(string searchString = "", int pageNo = 1, int pageSize = 4)
        {
            if (pageNo <= 0 || pageSize < 1)
            {
                throw new InvalidOperationException();
            }

            IEnumerable<JobOffer> record;
            if (String.IsNullOrEmpty(searchString))
            {
                record = await _context.JobOffers.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                record = await _context.JobOffers.Where(x => x.JobTitle.Contains(searchString)).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            }

            JobOfferPagingView offersData = new JobOfferPagingView
            {
                Offers = record,
                TotalCount = pageNo * pageSize
            };

            return offersData;
        }


        [HttpGet]
        public async Task<IActionResult> GetPagingBar(int pageNo = 1, int pageSize = 4, string searchString = "")
        {
            if (pageNo <= 0 || pageSize < 1)
            {
                return BadRequest();
            }

            int totalRecords;
            int totalPages;
            if (String.IsNullOrEmpty(searchString))
            {
                totalRecords = await _context.JobOffers.CountAsync();
                totalPages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
            }
            else
            {
                totalRecords = await _context.JobOffers.Where(x => x.JobTitle.Contains(searchString)).CountAsync();
                totalPages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
            }

            return PartialView("_PagingBar", (pageNo, totalPages, totalRecords));
        }

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


        [HttpGet]
        public async Task<IActionResult> IndexHR()
        {
            return View(await _context.JobOffers.Include(x => x.Company).ToListAsync());
        }

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

            return View(offer);
        }

        public async Task<ActionResult> Create()
        {
            var model = new JobOfferCreateView
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = await _context.Companies.ToListAsync();
                return View(model);
            }

            JobOffer offer = new JobOffer
            {
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

            var createView = new JobOfferCreateView(offer)
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(createView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JobOffer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobOffer offer = await _context.JobOffers.FirstOrDefaultAsync(o => o.Id == model.Id);

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

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id cannot be null");
            }

            _context.Remove(new JobOffer { Id = id.Value });
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexHR");
        }
    }
}
