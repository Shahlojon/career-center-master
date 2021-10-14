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
using AutoMapper.QueryableExtensions;
using CareerCenter.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminNewsController : DashboardBaseController
    {
        public AdminNewsController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ProjectTo<NewsView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NewsView>(news));
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsView newsview)
        {
            if (ModelState.IsValid)
            {
                var news = _mapper.Map<News>(newsview);
                if (newsview.ImageFile != null)
                    news.Image = await UploadFile(newsview.ImageFile);
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsview);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<NewsView>(news));
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsView newsview)
        {
            if (id != newsview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var  news = _mapper.Map<News>(newsview);
                    if (newsview.ImageFile != null)
                        news.Image = await UploadFile(newsview.ImageFile, newsview.Image);
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(newsview.Id))
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
            return View(newsview);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NewsView>(news));
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            DeleteFile(news.Image);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }

        public ActionResult NewsSearch(string name)
        {
            var allnews = _context.News.Where(a => a.Title.Contains(name)).ToList();
            return Json(allnews);
        }

       
    }
}
