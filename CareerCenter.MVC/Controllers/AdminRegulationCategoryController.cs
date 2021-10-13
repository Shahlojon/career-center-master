using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using CareerCenter.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRegulationCategoryController : DashboardBaseController
    {
        public AdminRegulationCategoryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        {
        }

        // GET: AdminRegulationCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegulationCategories.ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminRegulationCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulationCategory = await _context.RegulationCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regulationCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RegulationCategoryView>(regulationCategory));
        }

        // GET: AdminRegulationCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminRegulationCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RegulationCategoryView regulationCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<RegulationCategory>(regulationCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regulationCategory);
        }

        // GET: AdminRegulationCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulationCategory = await _context.RegulationCategories.FindAsync(id);
            if (regulationCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<RegulationCategoryView>(regulationCategory));
        }

        // POST: AdminRegulationCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegulationCategoryView regulationCategory)
        {
            if (id != regulationCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<RegulationCategory>(regulationCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegulationCategoryExists(regulationCategory.Id))
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
            return View(regulationCategory);
        }

        // GET: AdminRegulationCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulationCategory = await _context.RegulationCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regulationCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RegulationCategoryView>(regulationCategory));
        }

        // POST: AdminRegulationCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regulationCategory = await _context.RegulationCategories.FindAsync(id);
            _context.RegulationCategories.Remove(regulationCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegulationCategoryExists(int id)
        {
            return _context.RegulationCategories.Any(e => e.Id == id);
        }
    }
}
