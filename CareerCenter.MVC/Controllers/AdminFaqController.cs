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
    public class AdminFaqController : DashboardBaseController
    {

        public AdminFaqController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminFaq
        public async Task<IActionResult> Index()
        {
            var faqs = await _context.Faqs.ProjectTo<FaqView>(_mapper.ConfigurationProvider).ToListAsync();
            foreach(var faq in faqs)
            {
                faq.FaqCategory = _mapper.Map<FaqCategoryView>(_context.FaqCategories.Where(x => x.Id == faq.CategoryId).FirstOrDefault());
            }
            return View(faqs);
        }

        // GET: AdminFaq/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }
            var FaqView = _mapper.Map<FaqView>(faq);
            FaqView.FaqCategory = _mapper.Map<FaqCategoryView>(_context.FaqCategories.Where(x => x.Id == FaqView.CategoryId).FirstOrDefault());

            return View(FaqView);
        }

        // GET: AdminFaq/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.FaqCategories.Where(x=>x.IsActive).ProjectTo<FaqCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View();
        }

        // POST: AdminFaq/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( FaqView faq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Faq>(faq));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faq);
        }

        // GET: AdminFaq/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.FaqCategories.Where(x => x.IsActive).ProjectTo<FaqCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(_mapper.Map<FaqView>(faq));
        }

        // POST: AdminFaq/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FaqView faq)
        {
            if (id != faq.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Faq>(faq));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.Id))
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
            return View(faq);
        }

        // GET: AdminFaq/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FaqView>(faq));
        }

        // POST: AdminFaq/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);
            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqExists(int id)
        {
            return _context.Faqs.Any(e => e.Id == id);
        }
    }
}
