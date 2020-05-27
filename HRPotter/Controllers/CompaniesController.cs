using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static HRPotter.Controllers.UsersController;


namespace HRPotter.Controllers
{
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private readonly HRPotterContext _context;

        public CompaniesController(HRPotterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Main companies page
        /// </summary>
        /// <returns> Companies list </returns>
        [Route("[action]")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            return View(await _context.Companies.ToListAsync());
        }


        /// <returns> Partial view with list of companies</returns>
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCompaniesTable()
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            return PartialView("_CompaniesTable", await _context.Companies.ToListAsync());
        }

        /// <summary>
        ///     Create new company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        /// <summary>
        ///     Edit company
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Redirection to edit form</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }


        /// <param name="id"> Id of company </param>
        /// <param name="company"> New company </param>
        /// <returns> Redirection to index </returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Company company)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            if (company == null || id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        /// <summary>
        ///     Delete company - get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDeleteModal(int? id)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModal", (company.Name, company.Id, "Companies"));
        }

        /// <summary>
        ///     Delete company - post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("[action]/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
