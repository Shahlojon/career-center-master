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
using CareerCenter.MVC.Models;
using AutoMapper.QueryableExtensions;

namespace CareerCenter.MVC.Controllers
{
    public class AdminAnnouncementCategoryController : DashboardBaseController
    {

        public AdminAnnouncementCategoryController(CareerCenterDbContext context, IMapper mapper)
            : base(context, mapper)
        { }

        // GET: AdminPartnerCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnnouncementCategories.ProjectTo<AnnouncementCategoryView>(_mapper.ConfigurationProvider).ToListAsync());

        }

        // GET: AdminPartnerCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcementCategory = await _context.AnnouncementCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcementCategory == null)
            {
                return NotFound();
            }

            //return View(partnerCategory);
            return View(_mapper.Map<AnnouncementCategoryView>(announcementCategory));
        }

        // GET: AdminPartnerCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPartnerCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnnouncementCategoryView announcementCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<AnnouncementCategory>(announcementCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(announcementCategory);
        }

        // GET: AdminPartnerCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcementCategory = await _context.AnnouncementCategories.FindAsync(id);
            if (announcementCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<AnnouncementCategoryView>(announcementCategory));
        }

        // POST: AdminPartnerCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnnouncementCategoryView announcementCategory)
        {
            if (id != announcementCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<AnnouncementCategory>(announcementCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementCategoryExists(announcementCategory.Id))
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
            return View(announcementCategory);
        }

        // GET: AdminPartnerCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcementCategory = await _context.AnnouncementCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcementCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnnouncementCategoryView>(announcementCategory));
        }

        // POST: AdminPartnerCategory/Delete/5 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcementCategory = await _context.AnnouncementCategories.FindAsync(id);
            _context.AnnouncementCategories.Remove(announcementCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementCategoryExists(int id)
        {
            return _context.AnnouncementCategories.Any(e => e.Id == id);
        }
    }
}
