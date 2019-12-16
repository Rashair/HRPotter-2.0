using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using static HRPotter.Controllers.UsersController;

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
        [Route("")]
        [Route("/")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AuthorizeUser(_context, base.User);


            return View();
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
