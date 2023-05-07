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
