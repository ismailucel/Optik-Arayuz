using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Optik_Arayuz_UI.Data;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optik_Arayüz_UI.Controllers
{
    public class ComponentsPartial : Controller
    {
        private readonly OptikArayuzDbContext _context;
        public enum Columns{
            Logo = 3, Number = 4, Student = 2, Grade = 3, Choice = 5, Text = 3, Test = 3
        };
        public int[] values = {3,4,2,3,5,3,3};

        public ComponentsPartial(OptikArayuzDbContext context)
        {
            _context = context;
        }
        public IActionResult Logo(RequestContext requestContext)
        {
            
            int column = (int)Columns.Choice;
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
        public IActionResult Grade()
        {
            return PartialView();
        }
        public IActionResult Choice()
        {
            ViewData["number"] = 3;
            TempData["choices"] = new[] { "A", "B" ,"C"};
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
        public IActionResult Inputs()
        {

            string Forum = Request.Path.Value;
            var temp = Forum.Split("/");
            int columnNumber = (int)Enum.Parse(typeof(Columns), temp[temp.Length - 1]);
            ViewData["columnNumber"] = columnNumber;
            return PartialView();
        }
       
    }
}
