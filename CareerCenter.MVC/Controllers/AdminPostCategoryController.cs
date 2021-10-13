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
    public class AdminPostCategoryController : DashboardBaseController
    {

        public AdminPostCategoryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        {
        }

        // GET: AdminPostCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostCategories.ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminPostCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PostCategoryView>(postCategory));
        }

        // GET: AdminPostCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPostCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Title,Id,IsActive,CretedAt,UpdatedAt")] */PostCategoryView postCategory)
        {
            if (ModelState.IsValid)
            {


                _context.Add(_mapper.Map<PostCategory>(postCategory));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postCategory);
        }

        // GET: AdminPostCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories.FindAsync(id);
            if (postCategory == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PostCategoryView>(postCategory));
        }

        // POST: AdminPostCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,/* [Bind("Title,Id,IsActive,CretedAt,UpdatedAt")]*/ PostCategoryView postCategory)
        {
            if (id != postCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<PostCategory>(postCategory));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCategoryExists(postCategory.Id))
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
            return View(postCategory);
        }

        // GET: AdminPostCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View( _mapper.Map<PostCategoryView>(postCategory));
        }

        // POST: AdminPostCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postCategory = await _context.PostCategories.FindAsync(id);
            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCategoryExists(int id)
        {
            return _context.PostCategories.Any(e => e.Id == id);
        }
    }
}
