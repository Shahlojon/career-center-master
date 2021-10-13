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
using AutoMapper.QueryableExtensions;
using CareerCenter.MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : DashboardBaseController
    {
        public AdminUserController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminUser
        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.ProjectTo<UserView>(_mapper.ConfigurationProvider).ToListAsync();
            ViewBag.Roles = await _context.Roles.ToListAsync();
            foreach(var userRole in user)
            {
                userRole.UserRole = _mapper.Map<RoleView>(_context.Roles.Where(x => x.Name == userRole.Role).FirstOrDefault());
            }
            return View(user);
        }

        // GET: AdminUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserView>(user));
        }

        // GET: AdminUser/Create
        public async Task<IActionResult> Create()
        {
            //ViewBag.Categories = await _context.PostCategories.Where(x => x.IsActive == true)
            //    .ProjectTo<PostCategoryView>(_mapper.ConfigurationProvider).ToListAsync();
            ViewBag.Roles = await _context.Roles.ToListAsync();
            return View();
        }

        // POST: AdminUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserView user)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<User>();
                if (user.ImageFile != null)
                    user.Image = await UploadFile(user.ImageFile);
                user.PasswordHash = hasher.HashPassword(null, user.PasswordHash);
                var userModel = _mapper.Map<User>(user);
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                var role = await _context.Roles.Where(x => x.Name == userModel.Role).FirstOrDefaultAsync();
                _context.Add(new IdentityUserRole<int> { RoleId = role.Id, UserId = user.Id });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: AdminUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = await _context.Roles.ToListAsync();
            return View(_mapper.Map<UserView>(user));
        }

        // POST: AdminUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserView user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var hasher = new PasswordHasher<User>();
                    if (user.ImageFile != null)
                        user.Image = await UploadFile(user.ImageFile, user.Image);
                    user.PasswordHash = hasher.HashPassword(null, user.PasswordHash);
                    var userModel = _mapper.Map<User>(user);
                    _context.Update(userModel);
                    var role = await _context.Roles.Where(x => x.Name == userModel.Role).FirstOrDefaultAsync();
                    _context.Update(new IdentityUserRole<int> { RoleId = role.Id, UserId = user.Id });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: AdminUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserView>(user));
        }

        // POST: AdminUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            DeleteFile(user.Image);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
