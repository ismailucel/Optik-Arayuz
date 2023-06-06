using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;
using System.Diagnostics;

namespace Optik_Arayüz_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OptikArayuzDbContext _context;
        private readonly UserManager<User> _userManager;
        public HomeController(ILogger<HomeController> logger,OptikArayuzDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var optikArayuzDbContext = _context.Announcements.Include(a => a.User).OrderByDescending(x => x.AnnouncementDate).Take(6);

            return View(await optikArayuzDbContext.ToListAsync());
        }


        public IActionResult Help()
        {
            return View();
        }
   
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}