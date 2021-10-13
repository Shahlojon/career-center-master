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
    public class AdminGalleryController : DashboardBaseController
    {

        public AdminGalleryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminGallery
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galleries.ProjectTo<GalleryView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminGallery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<GalleryView>(gallery));
        }

        // GET: AdminGallery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminGallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryView galleryView)
        {
            if (ModelState.IsValid)
            {
                var gallery = _mapper.Map<Gallery>(galleryView);
                if (galleryView.FileUpload != null)
                    gallery.File = await UploadFile(galleryView.FileUpload);
                _context.Galleries.Add(gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galleryView);
        }

        // GET: AdminGallery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<GalleryView>(gallery));
        }

        // POST: AdminGallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryView gallery)
        {
            if (id != gallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var galleryId = await _context.Galleries.ProjectTo<GalleryView>(_mapper.ConfigurationProvider).Where(x=>x.Id==id).ToListAsync();
                    var galleryView = _mapper.Map<Gallery>(gallery);
                    if (gallery.FileUpload != null)
                        galleryView.File = await UploadFile(gallery.FileUpload, gallery.File);
                    _context.Update(galleryView);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.Id))
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
            return View(gallery);
        }

        // GET: AdminGallery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<GalleryView>(gallery));
        }

        // POST: AdminGallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
             DeleteFile(gallery.File);
            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
