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
    public class AdminRegulationController : DashboardBaseController
    {
        public AdminRegulationController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminRegulation
        public async Task<IActionResult> Index()
        {
            var regulations = await _context.Regulations.ProjectTo<RegulationView>(_mapper.ConfigurationProvider).ToListAsync();
            foreach (var regulation in regulations)
            {
                regulation.RegulationCategoryView = _mapper.Map<RegulationCategoryView>(_context.RegulationCategories.Where(x => x.Id == regulation.CategoryId).FirstOrDefault());
            }
            return View(regulations);
        }

        // GET: AdminRegulation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulation = await _context.Regulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regulation == null)
            {
                return NotFound();
            }
            //ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true && x.Id == regulation.CategoryId)
            //.ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            regulation.RegulationCategory = await _context.RegulationCategories.Where(x => x.IsActive == true && x.Id == regulation.CategoryId)
                .FirstOrDefaultAsync();
            return View(_mapper.Map<RegulationView>(regulation));
        }

        // GET: AdminRegulation/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true)
            .ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View();
        }

        // POST: AdminRegulation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegulationView regulationView)
        {
            if (ModelState.IsValid)
            {
                regulationView.File = await UploadFile(regulationView.FileUpload);
                _context.Add(_mapper.Map<Regulation>(regulationView));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true)
                .ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(regulationView);
        }

        // GET: AdminRegulation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulation = await _context.Regulations.FindAsync(id);
            if (regulation == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true)
               .ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(_mapper.Map<RegulationView>(regulation));
        }

        // POST: AdminRegulation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegulationView regulation)
        {
            if (id != regulation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Regulation>(regulation));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegulationExists(regulation.Id))
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
            ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true)
                .ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(regulation);
        }

        // GET: AdminRegulation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulation = await _context.Regulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regulation == null)
            {
                return NotFound();
            }
           /* ViewBag.Categories = await _context.RegulationCategories.Where(x => x.IsActive == true && x.Id == regulation.CategoryId)
              .ProjectTo<RegulationCategoryView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();*/
            regulation.RegulationCategory = await _context.RegulationCategories.Where(x => x.IsActive == true && x.Id == regulation.CategoryId)
                .FirstOrDefaultAsync();
            return View(_mapper.Map<RegulationView>(regulation));
        }

        // POST: AdminRegulation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regulation = await _context.Regulations.FindAsync(id);
            _context.Regulations.Remove(regulation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegulationExists(int id)
        {
            return _context.Regulations.Any(e => e.Id == id);
        }
    }
}
