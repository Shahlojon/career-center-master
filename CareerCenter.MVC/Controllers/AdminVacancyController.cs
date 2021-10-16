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
using AutoMapper.QueryableExtensions;
using CareerCenter.MVC.Models;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminVacancyController : DashboardBaseController
    {
        public AdminVacancyController(CareerCenterDbContext context, IMapper mapper)
            : base(context, mapper)
        { }

        // GET: AdminSettings
        public async Task<IActionResult> Index()
        {
            var vacancies =await _context.Vacancies.Include(f => f.University).Include(f => f.Category).ProjectTo<VacancyView>(_mapper.ConfigurationProvider).ToListAsync();
            //foreach (var vacancy in vacancies)
            //{
            //    vacancy.Category = _mapper.Map<VacancyCategoryView>(_context.VacancyCategories.Where(x => x.Id == vacancy.CategoryId).FirstOrDefault());
            //}
            return View(vacancies);
        }

        // GET: AdminSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = _mapper.Map<VacancyView>(await _context.Vacancies.Include(f => f.University).Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id));
            if (vacancy == null)
            {
                return NotFound();
            }
            //vacancy.Category = await _context.VacancyCategories.Where(x => x.IsActive == true && x.Id == vacancy.CategoryId)
            //    .ProjectTo<VacancyCategoryView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return View(vacancy);
        }

        // GET: AdminSettings/Create
        public async Task<IActionResult> Create()
        {
            //ViewBag.Categories = await _context.VacancyCategories.Where(x => x.IsActive == true)
            //  .ProjectTo<VacancyCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.VacancyCategories, "Id", "Title");
            return View();
        }

        // POST: AdminSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VacancyView vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Vacancy>(vacancy));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.VacancyCategories, "Id", "Title");
            return View(vacancy);
        }

        // GET: AdminSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies.Include(f => f.University).Include(f => f.Category).FirstOrDefaultAsync(x=>x.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", vacancy.UniversityId);
            ViewData["CategoryId"] = new SelectList(_context.VacancyCategories, "Id", "Title", vacancy.CategoryId);
            return View(_mapper.Map<VacancyView>(vacancy));
        }

        // POST: AdminSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VacancyView vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Vacancy>(vacancy));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.Id))
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
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", vacancy.UniversityId);
            ViewData["CategoryId"] = new SelectList(_context.VacancyCategories, "Id", "Title", vacancy.CategoryId);
            return View(vacancy);
        }

        // GET: AdminSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies.Include(f => f.University).Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }
            var vacancyView = _mapper.Map<VacancyView>(vacancy);
            //vacancyView.Category = _mapper.Map<VacancyCategoryView>(
            //    await _context.VacancyCategories.Where(x => x.IsActive == true && x.Id == vacancy.CategoryId)
            //    .FirstOrDefaultAsync());
            return View(_mapper.Map<VacancyView>(vacancy));
        }

        // POST: AdminSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
