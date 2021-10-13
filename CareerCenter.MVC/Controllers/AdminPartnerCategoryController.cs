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
    public class AdminPartnerCategoryController : DashboardBaseController
    {

        public AdminPartnerCategoryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminPartnerCategory
        public async Task<IActionResult> Index()
        {
            //return View(await _context.PartnerCategories.ToListAsync());
            return View(await _context.PartnerCategories.ProjectTo<PartnerCategoryView>(_mapper.ConfigurationProvider).ToListAsync());

        }

        // GET: AdminPartnerCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerCategory = await _context.PartnerCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerCategory == null)
            {
                return NotFound();
            }

            //return View(partnerCategory);
            return View(_mapper.Map<PartnerCategoryView>(partnerCategory));
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
        public async Task<IActionResult> Create(PartnerCategoryView partnerCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<PartnerCategory>(partnerCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerCategory);
        }

        // GET: AdminPartnerCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerCategory = await _context.PartnerCategories.FindAsync(id);
            if (partnerCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PartnerCategoryView>(partnerCategory));
        }

        // POST: AdminPartnerCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PartnerCategoryView partnerCategory)
        {
            if (id != partnerCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<PartnerCategory>(partnerCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerCategoryExists(partnerCategory.Id))
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
            return View(partnerCategory);
        }

        // GET: AdminPartnerCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partnerCategory = await _context.PartnerCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partnerCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PartnerCategoryView>(partnerCategory));
        }

        // POST: AdminPartnerCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partnerCategory = await _context.PartnerCategories.FindAsync(id);
            _context.PartnerCategories.Remove(partnerCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerCategoryExists(int id)
        {
            return _context.PartnerCategories.Any(e => e.Id == id);
        }
    }
}
