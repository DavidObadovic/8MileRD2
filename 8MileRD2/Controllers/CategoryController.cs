using _8MileRD2.Data;
using _8MileRD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8MileRD2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) => this._db = db;  

        public IActionResult Index()
        {
            List<Category> categories=_db.Categoies.ToList();
             return View(categories);
        }
    }
}
