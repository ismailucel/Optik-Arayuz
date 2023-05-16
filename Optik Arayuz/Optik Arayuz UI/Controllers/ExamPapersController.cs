using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;

namespace Optik_Arayüz_UI.Controllers
{
    public class ExamPapersController : Controller
    {
        private readonly OptikArayuzDbContext _context;

        public ExamPapersController(OptikArayuzDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult ExamPaperCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExamPaperCreate(ExamPaper examPaper)
        {
            _context.ExamPapers.Add(examPaper);

            _context.SaveChanges();

            return View();

        }

        public string SendDatabase(string value)
        {
            var components = value.Split("/");
            var paperId = _context.ExamPapers.OrderBy(m=> m.ExamPaperId).Last().ExamPaperId;
            int id = 0;
            for (int i = 0; i < components.Length; i++) { 
                var attr = components[i].Split("_");
                int index = Convert.ToInt32(attr[0].Substring(attr[0].Length-1));
                var type = attr[0][..^1];
                
                switch (type)
                {
                    case "Choice":
                        _context.Choices.Add(ComponentsPartial._choices[index]);
                        _context.SaveChanges();

                        id = _context.Choices.OrderBy(m=> m.ChoiceId).Last().ChoiceId;
                        break;
                    case "Logo":
                        _context.Logos.Add(ComponentsPartial._logos[index]);
                        _context.SaveChanges();

                        id = _context.Logos.OrderBy(m=> m.LogoId).Last().LogoId;
                        break;
                    case "Number":
                        _context.Numbers.Add(ComponentsPartial._numbers[index]);
                        _context.SaveChanges();

                        id = _context.Numbers.OrderBy(m=> m.NumberId).Last().NumberId;

                        break;
                    case "Student":
                        _context.Students.Add(ComponentsPartial._students[index]);
                        _context.SaveChanges();

                        id = _context.Students.OrderBy(m=> m.StudentId).Last().StudentId;

                        break;
                    case "Grade":
                        _context.Grades.Add(ComponentsPartial._grades[index]);
                        _context.SaveChanges();

                        id = _context.Grades.OrderBy(m=> m.GradeId).Last().GradeId;

                        break;
                    case "Text":
                        _context.Texts.Add(ComponentsPartial._texts[index]);
                        _context.SaveChanges();

                        id = _context.Texts.OrderBy(m=> m.TextId).Last().TextId;

                        break;
                    case "Test":
                        _context.Tests.Add(ComponentsPartial._tests[index]);
                        _context.SaveChanges();

                        id = _context.Tests.OrderBy(m=> m.TestId).Last().TestId;

                        break;
                    default:
                        break;

                }
                ExamPaperElement examPaperElement = new ExamPaperElement()
                {
                    Type = type,
                    X = Convert.ToDouble(attr[1]),
                    Y = Convert.ToDouble(attr[2]),
                    ExamPaperId = paperId,
                    ComponentId = id,
                };
                _context.ExamPaperElements.Add(examPaperElement);
                _context.SaveChanges();

            }
            Console.WriteLine(value);
            return "true";
        }

        // GET: ExamPapers
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.ExamPapers != null ? 
                          View(await _context.ExamPapers.ToListAsync()) :
                          Problem("Entity set 'OptikArayuzDbContext.ExamPapers'  is null.");
        }

        // GET: ExamPapers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers
                .FirstOrDefaultAsync(m => m.ExamPaperId == id);
            if (examPaper == null)
            {
                return NotFound();
            }

            return View(examPaper);
        }

        // GET: ExamPapers/Create
        [Authorize]
        public IActionResult Create()
        {
            Console.WriteLine("sa");
            return View();
        }

        
        // POST: ExamPapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ExamPaperId,ExamPaperName,ExamPaperTitle")] ExamPaper examPaper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examPaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examPaper);
        }

        // GET: ExamPapers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers.FindAsync(id);
            if (examPaper == null)
            {
                return NotFound();
            }
            return View(examPaper);
        }

        // POST: ExamPapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ExamPaperId,ExamPaperName,ExamPaperTitle")] ExamPaper examPaper)
        {
            if (id != examPaper.ExamPaperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examPaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamPaperExists(examPaper.ExamPaperId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(examPaper);
        }

        // GET: ExamPapers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers
                .FirstOrDefaultAsync(m => m.ExamPaperId == id);
            if (examPaper == null)
            {
                return NotFound();
            }

            return View(examPaper);
        }

        // POST: ExamPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamPapers == null)
            {
                return Problem("Entity set 'OptikArayuzDbContext.ExamPapers'  is null.");
            }
            var examPaper = await _context.ExamPapers.FindAsync(id);
            if (examPaper != null)
            {
                _context.ExamPapers.Remove(examPaper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamPaperExists(int id)
        {
          return (_context.ExamPapers?.Any(e => e.ExamPaperId == id)).GetValueOrDefault();
        }
    }
}
