using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;

namespace Optik_Arayüz_UI.Controllers
{

    public class AnnouncementsController : Controller
    {
        private readonly OptikArayuzDbContext _context;
        private readonly UserManager<User> _userManager;
        public AnnouncementsController(OptikArayuzDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var optikArayuzDbContext = _context.Announcements.Include(a => a.User);
            return PartialView(await optikArayuzDbContext.ToListAsync());
        }


       
    }
}
