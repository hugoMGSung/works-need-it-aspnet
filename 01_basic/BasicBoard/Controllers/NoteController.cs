using BasicBoard.Data;
using BasicBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicBoard.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        //public IActionResult Index()
        //{
        //    //IEnumerable<Note> objNoteList = _db.Notes.ToList();
        //    var objNoteList = _db.Notes.FromSql($"SELECT * FROM Notes").ToList();
        //    return View(objNoteList);
        //}

        public IActionResult Index(int page = 1)
        {
            int totalCount = _db.Notes.FromSql($"SELECT * FROM Notes").Count();
            int countList = 10;
            int totalPage = totalCount / countList;
            if (totalCount % countList > 0) totalPage++;
            if (totalPage < page) page = totalPage;

            int countPage = 10;
            int startPage = ((page - 1) / countPage) * countPage + 1;
            int endPage = startPage + countPage - 1;
            if (totalPage < endPage) endPage = totalPage;

            int startCount = ((page - 1) * countPage) + 1;
            int endCount = startCount + 9;

            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;

            var StartCount = new SqlParameter("StartCount", startCount);
            var EndCount = new SqlParameter("EndCount", endCount);

            var objNoteList = _db.Notes.FromSql($"EXECUTE dbo.NEW_PagingNote @StartCount={StartCount}, @EndCount={EndCount}").ToList();

            return View(objNoteList);
        }

        // GET
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["USER_ID"] = HttpContext.Session.GetString("USER_ID");
            ViewData["USER_NAME"] = HttpContext.Session.GetString("USER_NAME");

            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note objNote)
        {
            //if (objNote.Name == null)
            //{
            //    ModelState.AddModelError("CustomError", "The Name is mandatory.");
            //}
            //objNote.UserId = "auto-gen"; // 임의로 입력
            
            //if (ModelState.IsValid) 
            //{
            _db.Notes.Add(objNote);
            _db.SaveChanges();
            TempData["success"] = "Note inserted successfully";
            //}
            //else
            //{
            //    var errors = ModelState.Select(x => x.Value.Errors)
            //               .Where(y => y.Count > 0)
            //               .ToList();
            //}
            
            return RedirectToAction("Index", "Note");
        }

        // GET
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) 
            {
                return NotFound();
            }

            var noteFromDb = _db.Notes.Find(Id);
            //var noteFromDbFirst = _db.Notes.FirstOrDefault(u => u.Id == Id);
            //var noteFromDbSingle = _db.Notes.SingleOrDefault(u => u.Id == Id);

            if (noteFromDb == null)
            {
                return NotFound();
            }

            return View(noteFromDb);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note objNote)
        {
            objNote.UserId = "auto-gen"; // 임의로 입력
            _db.Notes.Update(objNote);
            _db.SaveChanges();
            TempData["success"] = "Note edited successfully";

            return RedirectToAction("Index", "Note");
        }

        // GET
        public IActionResult Delete(int? Id)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                TempData["error"] = "You can't delete the note";
                return RedirectToAction("Index", "Note");
            }

            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var noteFromDb = _db.Notes.Find(Id);
            //var noteFromDbFirst = _db.Notes.FirstOrDefault(u => u.Id == Id);
            //var noteFromDbSingle = _db.Notes.SingleOrDefault(u => u.Id == Id);

            if (noteFromDb == null)
            {
                return NotFound();
            }

            return View(noteFromDb);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Notes.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Notes.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Note deleted successfully";

            return RedirectToAction("Index", "Note");
        }

        // GET
        public IActionResult Details(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var noteFromDb = _db.Notes.Find(Id);
            if (noteFromDb == null)
            {
                return NotFound();
            }

            noteFromDb.ReadCount++;
            _db.Notes.Update(noteFromDb);
            _db.SaveChanges();

            return View(noteFromDb);
        }
    }
}
