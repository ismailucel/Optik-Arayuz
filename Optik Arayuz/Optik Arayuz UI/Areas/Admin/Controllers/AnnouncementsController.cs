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

namespace Optik_Arayüz_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        // GET: Admin/Announcements
        public async Task<IActionResult> Index()
        {
            var optikArayuzDbContext = _context.Announcements.Include(a => a.User);
            return View(await optikArayuzDbContext.ToListAsync());
        }

        // GET: Admin/Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return PartialView(announcement);
        }

        // GET: Admin/Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnouncementId,AnnouncementName,AnnouncementContent,AnnouncementDate,UserId")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                announcement.UserId = _userManager.GetUserId(HttpContext.User);
                announcement.AnnouncementDate = DateTime.Now.ToString();
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", announcement.UserId);
            return View(announcement);
        }

        // GET: Admin/Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", announcement.UserId);
            return PartialView(announcement);
        }

        // POST: Admin/Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnouncementId,AnnouncementName,AnnouncementContent,AnnouncementDate,UserId")] Announcement announcement)
        {
            if (id != announcement.AnnouncementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.AnnouncementId))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", announcement.UserId);
            return PartialView(announcement);
        }

        // GET: Admin/Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return PartialView(announcement);
        }

        // POST: Admin/Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Announcements == null)
            {
                return Problem("Entity set 'OptikArayuzDbContext.Announcements'  is null.");
            }
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
          return (_context.Announcements?.Any(e => e.AnnouncementId == id)).GetValueOrDefault();
        }
    }
}
