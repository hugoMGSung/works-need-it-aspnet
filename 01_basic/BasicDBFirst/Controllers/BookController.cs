using BasicDBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicDBFirst.Controllers
{
    public class BookController : Controller
    {
        private readonly BookrentalshopContext _db;

        public BookController(BookrentalshopContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Bookstbl> objNoteList = _db.Bookstbls.ToList();
            return View(objNoteList);
        }
    }
}
