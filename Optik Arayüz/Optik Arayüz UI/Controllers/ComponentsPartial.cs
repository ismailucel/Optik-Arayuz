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
            ViewData["src"] = "googleturtle.png";
            return PartialView();
        }
        public IActionResult Number()
        {
            ViewData["Length"] = 10;
            ViewData["Label"] = "Ogrenci Numarası";

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
            ViewData["number"] = 2;
            TempData["choices"] = new[] { "A", "B" };
            ViewData["label"] = "Kitapcık";
            return PartialView();
        }
        public IActionResult Text()
        {
            ViewData["text"] = "Merhaba";
            return PartialView();
        }
        public IActionResult Test()
        {  
            ViewData["QuestionCount"] = 10;
            ViewData["x"] = 120;
            return PartialView();
        }
    }
}
