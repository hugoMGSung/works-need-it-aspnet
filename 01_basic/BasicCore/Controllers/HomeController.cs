using BasicCore.Data;
using BasicCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var cateList = _db.Categories.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            ViewData["Greeting"] = "Hi~";
            ViewData["Info"] = new Info()
            {
                Name = "GilDong Hong",
                Address2 = "256beon-gil",
                Address1 = "Dongnae-gu, Busan",
                PostalCode = "46279"
            };

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}