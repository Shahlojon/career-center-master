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
    public class AdminArticleController : DashboardBaseController
    {

        public AdminArticleController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminArticle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ProjectTo<ArticleView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminArticle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ArticleView>(article));
        }

        // GET: AdminArticle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminArticle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ArticleView article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Article>(article));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: AdminArticle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ArticleView>(article));
        }

        // POST: AdminArticle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleView article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Article>(article));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            return View(article);
        }

        // GET: AdminArticle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ArticleView>(article));
        }

        // POST: AdminArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
