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
    public class AdminPartnerController : DashboardBaseController
    {
        //private readonly CareerCenterDbContext _context;

        public AdminPartnerController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
           : base(context, mapper, hostEnvironment)
        { } 

        //public AdminPartnerController(CareerCenterDbContext context)
        //{
        //    _context = context;
        //}

        // GET: AdminPartner
        public async Task<IActionResult> Index()
        {
            var partners = await _context.Partners.ProjectTo<PartnerView>(_mapper.ConfigurationProvider).ToListAsync();
            foreach (var partner in partners)
            {
                partner.PartnerCategory = _mapper.Map<PartnerCategoryView>(
                    _context.PartnerCategories.Where(x => x.Id == partner.CategoryId).FirstOrDefault());
            }
            return View(partners);
            //return View(await _context.Partners.ToListAsync());
        }

        // GET: AdminPartner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id); 
            if (partner == null)
            {
                return NotFound();
            }
            partner.PartnerCategory = await _context.PartnerCategories.Where(x => 
            x.IsActive == true && x.Id == partner.CategoryId).FirstOrDefaultAsync();
            return View(_mapper.Map<PartnerView>(partner));
            //return View(partner); 
        }

        // GET: AdminPartner/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.PartnerCategories.Where(x => x.IsActive == true)
                .ProjectTo<PartnerCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View();
        }

        // POST: AdminPartner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PartnerView partnerView)
        {
            if (ModelState.IsValid)
            {
                partnerView.Logo = await UploadFile(partnerView.FileUpload);
                var partner = _mapper.Map<Partner>(partnerView);
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partnerView);
        }

        // GET: AdminPartner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.PartnerCategories.Where(x => x.IsActive == true)
                .ProjectTo<PartnerCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(_mapper.Map<PartnerView>(partner));
        }

        // POST: AdminPartner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PartnerView partnerView)
        {
            if (id != partnerView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    partnerView.Logo = await UploadFile(partnerView.FileUpload);
                    var partner = _mapper.Map<Partner>(partnerView);
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partnerView.Id))
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
            return View(partnerView);
        }

        // GET: AdminPartner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }
            //ViewBag.Categories = await _context.PartnerCategories.Where(x => x.IsActive == true && x.Id == partner.CategoryId)
            //    .ProjectTo<PartnerCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            var partnerView = _mapper.Map<PartnerView>(partner);
            partnerView.PartnerCategory = _mapper.Map<PartnerCategoryView>(
                await _context.PartnerCategories.Where(x => x.IsActive == true && x.Id == partner.CategoryId)
                .FirstOrDefaultAsync());
            return View(partnerView);
        }

        // POST: AdminPartner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
