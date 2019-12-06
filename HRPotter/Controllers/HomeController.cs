using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using static HRPotter.Helpers.ViewsFactory;

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
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.HasClaim(claim => claim.Type.EndsWith("objectidentifier")))
            {
                var key = User.Claims.Where(claim => claim.Type.EndsWith("objectidentifier")).First().Value;
                if (!UserExists(key))
                {
                    var name = User.Claims.Where(claim => claim.Type.EndsWith("givenname")).First().Value;
                    var user = new User() { B2CKey = key, Name = name, RoleId = 1 };
                    _context.Add(user);
                    _context.SaveChangesAsync();
                }
            }

            return OkView(View());
        }

        private bool UserExists(string key)
        {
            return _context.Users.Any(e => e.B2CKey.Equals(key));
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
