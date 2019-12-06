using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using static HRPotter.Helpers.ViewsFactory;
using System.Security.Claims;

namespace HRPotter.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly HRPotterContext _context;

        public UsersController(HRPotterContext context)
        {
            _context = context;
            if (!IsAuthorized())
            {
                AuthorizeUser(_context, base.User);
            }
        }

        public static User HRPotterUser { get; set; }

        public static bool IsAuthorized()
        {
            return HRPotterUser != null;
        }

        public static void AuthorizeUser(HRPotterContext context, ClaimsPrincipal User)
        {
            if (User == null || !User.Identity.IsAuthenticated || !User.HasClaim(claim => claim.Type.EndsWith("objectidentifier")))
            {
                return;
            }

            var key = User.Claims.Where(claim => claim.Type.EndsWith("objectidentifier")).First().Value;
            var user = context.Users.Include(x => x.Role).FirstOrDefault(u => u.B2CKey == key);
            if (user == null)
            {
                var name = User.Claims.Where(claim => claim.Type.EndsWith("givenname")).First().Value;
                user = new User() { B2CKey = key, Name = name, RoleId = 1 };
                context.Users.Add(user);
                context.SaveChanges();

                user = context.Users.Include(x => x.Role).First(u => u.B2CKey == key);
            }
            HRPotterUser = user;
        }

        /// <summary>
        /// Main companies page
        /// </summary>
        /// <returns> Companies list </returns>
        [Route("[action]")]
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <returns> Partial view with list of users </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUsersTable(string searchString)
        {
            List<User> result;
            if (String.IsNullOrEmpty(searchString))
            {
                result = await _context.Users.Include(x => x.Role).ToListAsync();
            }
            else
            {
                result = await _context.Users.Include(x => x.Role).Where(u => u.Name.Contains(searchString)).ToListAsync();
            }

            return PartialView("_UsersTable", result);
        }

        /// <summary>
        ///     Edit user - get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEditModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(m => m.Id.Equals(id));
            if (user == null)
            {
                return NotFound();
            }

            var editView = new UserEditView(user)
            {
                Roles = await _context.Roles.ToListAsync()
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

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDeleteModal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id.Equals(id));
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
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
