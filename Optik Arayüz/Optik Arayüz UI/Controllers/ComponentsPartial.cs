using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optik_Arayüz_UI.Data;
using System;

namespace Optik_Arayüz_UI.Controllers
{
    public class ComponentsPartial : Controller
    {
        private readonly OptikArayuzDbContext _context;

        public ComponentsPartial(OptikArayuzDbContext context)
        {
            _context = context;
        }
        public IActionResult Logo()
        {
            return PartialView();
        }
        public IActionResult Number()
        {
            return PartialView();
        }
        public IActionResult Student()
        {
            return PartialView();
        }
        public IActionResult Score()
        {
            return PartialView();
        }
        public IActionResult Choose()
        {
            return PartialView();
        }
        public IActionResult Text()
        {
            return PartialView();
        }
        public IActionResult Test()
        {  
            ViewData["QuestionCount"] = _context.Tests.Where(test => test.TestId == 2).Select(test1 => test1.QuestionCount).ToList()[0];
            ViewData["x"] = _context.Tests.Where(test => test.TestId == 2).Select(test1 => test1.XLength).ToList()[0];
            return PartialView();
        }
    }
}
