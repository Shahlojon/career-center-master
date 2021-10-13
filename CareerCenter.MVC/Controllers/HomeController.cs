using CareerCenter.Core.Contexts;
using CareerCenter.Core.Models;
using CareerCenter.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CareerCenterDbContext db;
        public HomeController(ILogger<HomeController> logger, CareerCenterDbContext ctx)
        {
            _logger = logger;
            db = ctx;
        }

        public IActionResult Index()
        {
            //var test = new Article();
            //test.Authors = "A?A";
            //test.Title = "title";
            //test.Content = "Content";
            //db.Articles.Add(test);
            //db.SaveChanges();
        var user = User.Identity;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
