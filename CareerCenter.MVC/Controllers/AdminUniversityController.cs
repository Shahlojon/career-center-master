using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using CareerCenter.MVC.Models;
using AutoMapper.QueryableExtensions;

namespace CareerCenter.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUniversityController : DashboardBaseController
    {

        public AdminUniversityController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }


        // GET: AdminAnnouncement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universities.ProjectTo<UniversityView>(_mapper.ConfigurationProvider).ToListAsync());
        }

        // GET: AdminAnnouncement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UniversityView>(university));
        }

        // GET: AdminAnnouncement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAnnouncement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniversityView university, IEnumerable<string> Title, IEnumerable<string> nameDekan)
        {
            if (ModelState.IsValid)
            {
                if (university.FileUpload != null)
                    university.Image = await UploadFile(university.FileUpload);
                /*foreach(var title in Title)
                {
                    foreach(var dekan in nameDekan)
                    {
                        var faculties = new FacultyView();
                        faculties.Title = title;
                        faculties.NameDekan = dekan;
                        faculties.UniversityId = university.Id;
                        _context.Add(_mapper.Map<Faculty>(faculties));
                    }
                }*/
                var universityModel = _mapper.Map<University>(university);
                _context.Universities.Add(universityModel);
                await _context.SaveChangesAsync();
                for(int i=0; i<Title.Count(); i++)
                {
                    var Faculty = new Faculty();
                    Faculty.Title = Title.ElementAt(i);
                    Faculty.NameDekan = nameDekan.ElementAt(i);
                    Faculty.UniversityId = universityModel.Id;
                    _context.Faculties.Add(Faculty);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: AdminAnnouncement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(id);
            var faculties = await _context.Faculties.Where(x => x.UniversityId == university.Id).ToListAsync();
            for(int i=0; i<faculties.Count(); i++)
            {
                university.Faculties.ElementAt(i).Title = faculties[i].Title;
                university.Faculties.ElementAt(i).NameDekan = faculties[i].NameDekan;
            }
            //foreach (var faculty  in faculties)
            //{
            //    university.Faculties.First().Title = faculty.Title;
            //    university.Faculties.First().NameDekan = faculty.NameDekan;
            //}
            if (university == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<UniversityView>(university));
        }

        // POST: AdminAnnouncement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UniversityView university, IEnumerable<int> IdF, IEnumerable<string> Title, IEnumerable<string> nameDekan)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (university.FileUpload != null)
                        university.Image = await UploadFile(university.FileUpload, university.Image);
                    var universityModel = _mapper.Map<University>(university);
                    _context.Update(universityModel);
                    await _context.SaveChangesAsync();

                    //var oldfaculties = _context.Faculties.Where(x => x.UniversityId == university.Id).ToList();
                    //_context.Faculties.RemoveRange(oldfaculties);
                    //await _context.SaveChangesAsync();
                    for (int i = 0; i < IdF.Count(); i++)
                    {

                        var faculty = new Faculty();
                        faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.Id == IdF.ElementAt(i));
                        faculty.Title = Title.ElementAt(i);
                        faculty.NameDekan = nameDekan.ElementAt(i);
                        faculty.UniversityId = university.Id;
                        _context.Faculties.Update(faculty);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(university.Id))
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
            return View(university);
        }

        // GET: AdminAnnouncement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AnnouncementView>(announcement));
        }

        // POST: AdminAnnouncement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var university = await _context.Universities.FindAsync(id);
            DeleteFile(university.Image);
            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Universities.Any(e => e.Id == id);
        }
    }
}
