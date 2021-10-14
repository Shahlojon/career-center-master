using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using CareerCenter.MVC.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAnnouncementController : DashboardBaseController
    {

        public AdminAnnouncementController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }


        // GET: AdminAnnouncement постав
        public async Task<IActionResult> Index()
        {
            return View(await _context.Announcements.Include(f => f.University).Include(f=>f.Category)
                .ProjectTo<AnnouncementView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminAnnouncement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.Include(f => f.University).Include(f=>f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnnouncementView>(announcement));
        }

        // GET: AdminAnnouncement/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.AnnouncementCategories, "Id", "Title");
            return View();
        }

        // POST: AdminAnnouncement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnnouncementView announcement)
        {
            if (ModelState.IsValid)
            {
                if (announcement.FileUpload != null)
                    announcement.Image = await UploadFile(announcement.FileUpload);
                _context.Add(_mapper.Map<Announcement>(announcement));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", announcement.UniversityId);
            ViewData["CategoryId"] = new SelectList(_context.AnnouncementCategories,"Id","Title", announcement.CategoryId);
            return View(announcement);
        }

        // GET: AdminAnnouncement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.Include(f => f.University).Include(f=>f.Category).FirstOrDefaultAsync(x=>x.Id ==id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", announcement.UniversityId);
            ViewData["CategoryId"] = new SelectList(_context.AnnouncementCategories,"Id","Title", announcement.CategoryId);
            return View(_mapper.Map<AnnouncementView>(announcement));
        }

        // POST: AdminAnnouncement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnnouncementView announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (announcement.FileUpload!=null)
                        announcement.Image = await UploadFile(announcement.FileUpload, announcement.Image);
                    
                    _context.Update(_mapper.Map<Announcement>(announcement));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
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
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", announcement.UniversityId);
            ViewData["CategoryId"] = new SelectList(_context.AnnouncementCategories, "Id", "Title", announcement.CategoryId); 
            return View(announcement);
        }

        // GET: AdminAnnouncement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.Include(f => f.University ).Include(f=> f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnnouncementView>(announcement));
        }

        // POST: AdminAnnouncement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            DeleteFile(announcement.Image);
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
