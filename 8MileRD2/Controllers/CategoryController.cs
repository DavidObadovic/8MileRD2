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
            List<Category> categories = _db.Categoies.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name != null)
                if (obj.Name.ToLower() == obj.DisplayOrder.ToString().ToLower())
                    ModelState.AddModelError("DisplayOrder", "Ne mozete imati isto ime i broj");

            if (ModelState.IsValid)
            {
                _db.Categoies.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category category = _db.Categoies.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categoies.Update(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category category = _db.Categoies.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categoies.Find(id);
            if (obj == null)
                return NotFound();

            _db.Categoies.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
