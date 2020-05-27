using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using static HRPotter.Controllers.UsersController;

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
        [Route("")]
        [Route("/")]
        [Route("[action]")]
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("[action]")]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
