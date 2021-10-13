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
    public class AdminPostController : DashboardBaseController
    {

        public AdminPostController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment) 
            :base(context, mapper, hostEnvironment)
        {}

        // GET: AdminPost
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.ProjectTo<PostView>(_mapper.ConfigurationProvider).ToListAsync();
            foreach(var post in posts)
            {
                post.PostCategory = _mapper.Map<PostCategoryView>(_context.PostCategories.Where(x => x.Id == post.CategoryId).FirstOrDefault());
            }
            return View(posts);
        }

        // GET: AdminPost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true && x.Id==post.CategoryId)
                .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return View(_mapper.Map<PostView>(post));
        }

        // GET: AdminPost/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true)
                .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View();
        }

        // POST: AdminPost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostView postView)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(postView);
                if(postView.ImageFile!=null)
                    post.Image = await UploadFile(postView.ImageFile);
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true)
                .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(postView);
        }

        // GET: AdminPost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true)
                .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            return View(_mapper.Map<PostView>( post));
        }

        // POST: AdminPost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PostView postView)
        {
            if (id != postView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var post = _mapper.Map<Post>(postView);
                    if (postView.ImageFile != null)
                        post.Image = await UploadFile(postView.ImageFile,postView.Image);
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(postView.Id))
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
            return View(postView);
        }

        // GET: AdminPost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true && x.Id == post.CategoryId)
                .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return View(_mapper.Map<PostView>(post));
        }

        // POST: AdminPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);

             DeleteFile(post.Image);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
