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
    public class AdminNotableStudentController : DashboardBaseController
    {

        public AdminNotableStudentController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminNotableStudent
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotableStudents.ProjectTo<NotableStudentView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminNotableStudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notableStudent = await _context.NotableStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notableStudent == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NotableStudentView>(notableStudent));
        }

        // GET: AdminNotableStudent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminNotableStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( NotableStudentView notableStudent)
        {
            if (ModelState.IsValid)
            {
                if (notableStudent.FileUpload != null) 
                    notableStudent.Image = await UploadFile(notableStudent.FileUpload);
                _context.Add(_mapper.Map<NotableStudent>(notableStudent));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notableStudent);
        }

        // GET: AdminNotableStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notableStudent = await _context.NotableStudents.FindAsync(id);
            if (notableStudent == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<NotableStudentView>(notableStudent));
        }

        // POST: AdminNotableStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NotableStudentView notableStudent)
        {
            if (id != notableStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    notableStudent.Image = await UploadFile(notableStudent.FileUpload, notableStudent.Image);
                    _context.Update(_mapper.Map<NotableStudent>(notableStudent));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotableStudentExists(notableStudent.Id))
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
            return View(notableStudent);
        }

        // GET: AdminNotableStudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notableStudent = await _context.NotableStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notableStudent == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NotableStudentView>(notableStudent));
        }

        // POST: AdminNotableStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notableStudent = await _context.NotableStudents.FindAsync(id);
            DeleteFile(notableStudent.Image);
            _context.NotableStudents.Remove(notableStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotableStudentExists(int id)
        {
            return _context.NotableStudents.Any(e => e.Id == id);
        }
    }
}
