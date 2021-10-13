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

namespace CareerCenter.MVC.Controllers
{
    public class AdminFacultyController : DashboardBaseController
    {


        public AdminFacultyController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }

        // GET: AdminFaculty
        public async Task<IActionResult> Index(int? UniversityId)
        {
            var careerCenterDbContext = _context.Faculties.Where(x=>x.UniversityId==UniversityId.Value).Include(f => f.University);
            
            var faculties = await careerCenterDbContext.ProjectTo<FacultyView>(_mapper.ConfigurationProvider).ToListAsync();

            ViewBag.UniversityId = UniversityId;
                return View(faculties);
        }

        // GET: AdminFaculty/Details/1(UniversityId)/5
        public async Task<IActionResult> Details(int?UniversityId, int? id)
        {
            if (id == null || UniversityId==null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .Include(f => f.University)
                .FirstOrDefaultAsync(m => m.Id == id && m.UniversityId == UniversityId.Value);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FacultyView>(faculty));
        }

        // GET: AdminFaculty/Create/1
        public async Task<IActionResult> Create(int? UniversityId)
        {
            //ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id");
            var un = await _context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value);
            ViewData["UniversityId"] = un?.Id;
            return View();
        }

        // POST: AdminFaculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? UniversityId, FacultyView faculty)
        {
            if (_context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value) == null || UniversityId.Value!=faculty.UniversityId)
                return BadRequest();
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Faculty>(faculty));
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index)+"?UniversityId="+UniversityId);
                return Redirect("/AdminFaculty?UniversityId="+UniversityId);
            }
            //ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", faculty.UniversityId);

            ViewData["UniversityId"] = (await _context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value))?.Id;
            return View(faculty);
        }

        // GET: AdminFaculty/Edit/5
        public async Task<IActionResult> Edit(int? UniversityId, int? id)
        {
            if (id == null|| UniversityId==null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties.FirstOrDefaultAsync(x=>x.Id==id && x.UniversityId==UniversityId.Value);
            if (faculty == null)
            {
                return NotFound();
            }
            //ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", faculty.UniversityId);

            ViewData["UniversityId"] = (await _context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value))?.Id;
            return View(_mapper.Map<FacultyView>(faculty));
        }

        // POST: AdminFaculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? UniversityId, int id, FacultyView faculty)
        {
            if (id != faculty.Id || UniversityId.Value!=faculty.UniversityId || _context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value) == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Faculty>(faculty));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(UniversityId,faculty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Redirect("/AdminFaculty?UniversityId=" + UniversityId);
            }
            //ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", faculty.UniversityId);

            ViewData["UniversityId"] = (await _context.Universities.FirstOrDefaultAsync(x => x.Id == UniversityId.Value))?.Id;
            return View(faculty);
        }

        // GET: AdminFaculty/Delete/5
        public async Task<IActionResult> Delete(int? UniversityId, int? id)
        {
            if (id == null || UniversityId==null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .Include(f => f.University)
                .FirstOrDefaultAsync(m => m.Id == id && m.UniversityId == UniversityId.Value);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FacultyView>(faculty));
        }

        // POST: AdminFaculty/Delete/1/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? UniversityId, int id)
        {
            var faculty = await _context.Faculties.FirstOrDefaultAsync(x=>x.UniversityId == UniversityId.Value && x.Id ==id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return Redirect("/AdminFaculty?UniversityId=" + UniversityId);
        }

        private bool FacultyExists(int? UniversityId, int id)
        {
            return _context.Faculties.Any(e => e.Id == id && e.UniversityId==UniversityId.Value);
        }
    }
}
