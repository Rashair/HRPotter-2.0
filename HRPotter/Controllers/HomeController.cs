using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using static HRPotter.Helpers.ViewsFactory;
using static HRPotter.Controllers.UsersController;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRPotter.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly HRPotterContext _context;

        public HomeController(HRPotterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Main page
        /// </summary>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("")]
        [Route("/")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                await AuthorizeUser();
            }

            return OkView(View());
        }

        private async Task AuthorizeUser()
        {
            if(!User.HasClaim(claim => claim.Type.EndsWith("objectidentifier")))
            {
                return;
            }

            var key = User.Claims.Where(claim => claim.Type.EndsWith("objectidentifier")).First().Value;
            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.B2CKey == key);
            if (user == null)
            {
                var name = User.Claims.Where(claim => claim.Type.EndsWith("givenname")).First().Value;
                user = new User() { B2CKey = key, Name = name, RoleId = 1 };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                user = await _context.Users.Include(x => x.Role).FirstAsync(u => u.B2CKey == key);
            }
            HRPotterUser = user;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
