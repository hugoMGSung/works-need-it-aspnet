using BoardCoreMySql.Data;
using BoardCoreMySql.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardCoreMySql.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> objNoteList = _db.Notes.ToList();
            return View(objNoteList);
        }

    }
}
