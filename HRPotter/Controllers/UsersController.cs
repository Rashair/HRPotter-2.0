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
    [Authorize]
    public class UsersController : Controller
    {
        private readonly HRPotterContext _context;
        private readonly IHttpContextAccessor httpContext;

        public UsersController(HRPotterContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            httpContext = httpContextAccessor;
            if (!IsAuthorized())
            {
                // AuthorizeUser(_context, httpContextAccessor.HttpContext.User);
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

            var key = User.Claims.Where(claim => claim.Type.EndsWith("objectidentifier")).FirstOrDefault()?.Value;
            var hrpotterUser = context.Users.Include(x => x.Role).FirstOrDefault(u => u.B2CKey == key);
            if (hrpotterUser == null)
            {
                var name = User.Claims.Where(claim => claim.Type.EndsWith("givenname")).FirstOrDefault()?.Value;
                if (name == null)
                {
                    throw new AuthenticationException("User not authenticated properly via Azure B2C");
                }

                hrpotterUser = new User() { B2CKey = key, Name = name, RoleId = 1 };
                context.Users.Add(hrpotterUser);
                context.SaveChanges();

                hrpotterUser = context.Users.Include(x => x.Role).First(u => u.B2CKey == key);
            }
            HRPotterUser = hrpotterUser;

            if (User.Identity is ClaimsIdentity identity && User.Identity.IsAuthenticated)
            {
                Console.WriteLine("Identyfing");
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, hrpotterUser.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, hrpotterUser.Name));
                identity.AddClaim(new Claim(ClaimTypes.Role, hrpotterUser.Role));
                identity.AddClaim(new Claim(ClaimTypes.GroupSid, hrpotterUser.RoleId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Sid, hrpotterUser.B2CKey));
                Console.WriteLine(hrpotterUser.Role);
                Console.WriteLine(User.IsInRole("Admin"));
            }
            else
            {
                Console.WriteLine($"Identyfing not: {User.Identity.Name}");
            }
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
