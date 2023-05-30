using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;

namespace Optik_Arayüz_UI.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExamtController : Controller
    {

        public ExamtController()
        {
        }

        // GET: Exams
        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }


    }
}
