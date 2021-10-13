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
    public class AdminFaqCategoryController : DashboardBaseController
    {

        public AdminFaqCategoryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminFaqCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaqCategories.ProjectTo<FaqCategoryView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminFaqCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqCategory = await _context.FaqCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FaqCategoryView>( faqCategory));
        }

        // GET: AdminFaqCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminFaqCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FaqCategoryView faqCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<FaqCategory>(faqCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faqCategory);
        }

        // GET: AdminFaqCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqCategory = await _context.FaqCategories.FindAsync(id);
            if (faqCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<FaqCategoryView>(faqCategory));
        }

        // POST: AdminFaqCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FaqCategoryView faqCategory)
        {
            if (id != faqCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<FaqCategory>(faqCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqCategoryExists(faqCategory.Id))
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
            return View(faqCategory);
        }

        // GET: AdminFaqCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faqCategory = await _context.FaqCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faqCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FaqCategoryView>(faqCategory));
        }

        // POST: AdminFaqCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faqCategory = await _context.FaqCategories.FindAsync(id);
            _context.FaqCategories.Remove(faqCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqCategoryExists(int id)
        {
            return _context.FaqCategories.Any(e => e.Id == id);
        }
    }
}
