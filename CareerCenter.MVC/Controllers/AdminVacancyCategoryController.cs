using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using CareerCenter.MVC.Models;
using AutoMapper.QueryableExtensions;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminVacancyCategoryController : DashboardBaseController
    {

        public AdminVacancyCategoryController(CareerCenterDbContext context, IMapper mapper)
            : base(context, mapper)
        { }

        // GET: AdminPartnerCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacancyCategories.ProjectTo<VacancyCategoryView>(_mapper.ConfigurationProvider).ToListAsync());

        }

        // GET: AdminPartnerCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyCategory = await _context.VacancyCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyCategory == null)
            {
                return NotFound();
            }

            //return View(partnerCategory);
            return View(_mapper.Map<VacancyCategoryView>(vacancyCategory));
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
        public async Task<IActionResult> Create(VacancyCategoryView vacancyCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<VacancyCategory>(vacancyCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancyCategory);
        }

        // GET: AdminPartnerCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyCategory = await _context.VacancyCategories.FindAsync(id);
            if (vacancyCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<VacancyCategoryView>(vacancyCategory));
        }

        // POST: AdminPartnerCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VacancyCategoryView vacancyCategory)
        {
            if (id != vacancyCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<VacancyCategory>(vacancyCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerCategoryExists(vacancyCategory.Id))
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
            return View(vacancyCategory);
        }

        // GET: AdminPartnerCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancyCategory = await _context.VacancyCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VacancyCategoryView>(vacancyCategory));
        }

        // POST: AdminPartnerCategory/Delete/5 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancyCategory = await _context.VacancyCategories.FindAsync(id);
            _context.VacancyCategories.Remove(vacancyCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerCategoryExists(int id)
        {
            return _context.VacancyCategories.Any(e => e.Id == id);
        }
    }
}
