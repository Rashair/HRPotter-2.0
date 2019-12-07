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
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly HRPotterContext _context;

        public UsersController(HRPotterContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            if (!IsAuthorized())
            {
                AuthorizeUser(_context, httpContextAccessor.HttpContext.User);
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
        public IActionResult Index()
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            return View();
        }

        /// <returns> Partial view with list of users </returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUsersTable(string searchString)
        {
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            List<User> result;
            if (String.IsNullOrEmpty(searchString))
            {
                result = await _context.Users.Include(x => x.Role).Where(x => x.RoleId != 3).ToListAsync();
            }
            else
            {
                result = await _context.Users.Include(x => x.Role).Where(x => x.RoleId != 3).Where(u => u.Name.Contains(searchString)).ToListAsync();
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
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

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
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
            if (HRPotterUser.Role != "Admin")
            {
                return Forbid();
            }

            var user = await _context.Users.Where(x => x.Id == id && x.RoleId != 3).FirstOrDefaultAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
