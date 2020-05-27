using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRPotter.Controllers
{
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly HRPotterContext _context;

        public UsersController(HRPotterContext context)
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
        public IActionResult Index()
        {
            return View();
        }

        /// <returns> Partial view with list of users </returns>
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUsersTable(string searchString)
        {
            List<User> result;
            if (String.IsNullOrEmpty(searchString))
            {
                result = await _context.Users.Include(x => x.Role).Where(x => x.RoleId != 3).ToListAsync();
            }
            else
            {
                searchString = searchString.ToLower();
                result = await _context.Users.Include(x => x.Role).Where(x => x.RoleId != 3).Where(u => u.Name.Contains(searchString)).ToListAsync();
            }

            return PartialView("_UsersTable", result);
        }

        /// <summary>
        ///     Edit user - get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEditModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Role).Where(x => x.RoleId != 3).FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (user == null)
            {
                return NotFound();
            }

            var editView = new UserEditView(user)
            {
                Roles = await _context.Roles.Where(x => x.Id != 3).ToListAsync()
            };

            return PartialView("_EditModal", editView);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole(int? id, int? roleId)
        {
            if (id == null || roleId == null)
            {
                return BadRequest();
            }

            var user = await _context.Users.Where(x => x.RoleId != 3).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.RoleId = roleId.Value;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        ///     Delete user - get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDeleteModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Where(x => x.RoleId != 3).FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (user == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteModal", (user.Name, user.Id, "Users"));
        }


        [Route("[action]/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id && x.Role != "Admin").FirstOrDefaultAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
