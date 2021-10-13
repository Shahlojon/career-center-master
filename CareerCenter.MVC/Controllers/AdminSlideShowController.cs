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
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSlideShowController : DashboardBaseController
    {
        public AdminSlideShowController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvirontment)
            : base(context, mapper, hostEnvirontment)
        { }

        // GET: AdminSlideShow
        public async Task<IActionResult> Index()
        {
            return View(await _context.SlideShows.ProjectTo<SlideShowView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminSlideShow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slideShow == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<SlideShowView>(slideShow));
        }

        // GET: AdminSlideShow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminSlideShow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SlideShowView slideShowView)
        {
            if (ModelState.IsValid)
            {
                if (slideShowView.FileUpload != null)
                    slideShowView.Image = await UploadFile(slideShowView.FileUpload);
                _context.Add(_mapper.Map<SlideShow>(slideShowView));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slideShowView);
        }

        // GET: AdminSlideShow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShows.FindAsync(id);
            if (slideShow == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<SlideShowView>(slideShow));
        }

        // POST: AdminSlideShow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SlideShowView slideShow)
        {
            if (id != slideShow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (slideShow.FileUpload != null)
                        slideShow.Image = await UploadFile(slideShow.FileUpload, slideShow.Image);
                    _context.Update(_mapper.Map<SlideShow>(slideShow));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlideShowExists(slideShow.Id))
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
            return View(slideShow);
        }

        // GET: AdminSlideShow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slideShow = await _context.SlideShows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slideShow == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<SlideShowView>(slideShow));
        }

        // POST: AdminSlideShow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slideShow = await _context.SlideShows.FindAsync(id);
            DeleteFile(slideShow.Image);
            _context.SlideShows.Remove(slideShow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideShowExists(int id)
        {
            return _context.SlideShows.Any(e => e.Id == id);
        }
    }
}
