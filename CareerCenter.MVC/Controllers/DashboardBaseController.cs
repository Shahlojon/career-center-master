using AutoMapper;
using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Controllers
{
    public abstract partial class DashboardBaseController : Controller
    {
        public readonly CareerCenterDbContext _context;
        public readonly IMapper _mapper;
        public User CurrentUser;
        private readonly IWebHostEnvironment _hostEnvironment;
        public string wwwRootPath;

        public DashboardBaseController(CareerCenterDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            wwwRootPath = _hostEnvironment.WebRootPath;
            if (User!=null && User.Identity.IsAuthenticated)
                CurrentUser =  _context.Users.Where(x=> x.UserName == User.Identity.Name).FirstOrDefault();
        }

        protected DashboardBaseController(CareerCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<string> UploadFile(IFormFile file, string oldFile=null)
        {
            if (file != null)
            {
                //string fileNameImage = Path.GetFileNameWithoutExtension(file.FileName);
                string extensionImage = Path.GetExtension(file.FileName);
                //string fileName =  DateTime.Now.ToString("yymmssfff")+"_"+Guid.NewGuid().ToString() + extensionImage;
                string fileName = Guid.NewGuid().ToString() + extensionImage;

                string path = Path.Combine(wwwRootPath + "/uploads/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                DeleteFile(oldFile);
                return fileName;
            }
            return oldFile;

            
        }

        protected void DeleteFile(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                var imagePath = Path.Combine(wwwRootPath, "uploads", file);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }
        }
    }
}
