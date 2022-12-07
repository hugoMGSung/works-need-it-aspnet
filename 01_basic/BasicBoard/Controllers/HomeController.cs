using BasicBoard.Data;
using BasicBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Drawing;

namespace BasicBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var loginUser = _db.Users.FromSql($"SELECT * FROM Users WHERE UserId = {user.UserId} AND Password = {user.Password} ").FirstOrDefault();

            if (loginUser != null)
            {
                HttpContext.Session.SetInt32("USER_LOGIN_KEY", loginUser.Id);
                HttpContext.Session.SetString("USER_NAME", loginUser.UserName);
                HttpContext.Session.SetString("USER_ID", loginUser.UserId);
                return RedirectToAction("Index", "Home");
            } 
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.PasswordCheck)
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    TempData["success"] = "User added successfully";

                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            HttpContext.Session.Remove("USER_NAME");
            HttpContext.Session.Remove("USER_ID");

            return RedirectToAction("Index", "Home");
        }
    }
}