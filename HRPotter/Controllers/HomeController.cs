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

        public HomeController(HRPotterContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            if (!IsAuthorized())
            {
                AuthorizeUser(_context, httpContextAccessor.HttpContext.User);
            }
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
            AuthorizeUser(_context, base.User);


            return OkView(View());
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
