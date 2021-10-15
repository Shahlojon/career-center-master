using AutoMapper;
using AutoMapper.QueryableExtensions;
using CareerCenter.Core.Contexts;
using CareerCenter.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Controllers
{
    public class DictionaryController:DashboardBaseController
    {
        public DictionaryController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper, hostEnvironment)
        { }


        public async Task<IEnumerable<FacultyView>> GetFaculty(int? id)
        {
            if (id.HasValue)
            {
                var faculties = await _context.Faculties.Where(x => x.UniversityId == id.Value)
                    .ProjectTo<FacultyView>(_mapper.ConfigurationProvider).ToListAsync();
                return faculties;
            }
            return new List<FacultyView>();
        }


    }
}
