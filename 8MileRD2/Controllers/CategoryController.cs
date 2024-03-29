﻿using _8MileRD.DataAccess.Repository;
using _8MileRD.DataAccess.Repository.IRepository;
using _8MileRD.Models;
using _8MileRD2.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace _8MileRD2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db) => this._db = db;

        public IActionResult Index()
        {
            List<Category> categories = _db.categoryRepository.GetAll().ToList();
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
                _db.categoryRepository.Add(obj);
                _db.Save();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Save(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.categoryRepository.Update(category);
                _db.Save();
            }
            return RedirectToAction("Index");
        }
        [ActionName("Save")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category category = _db.categoryRepository.get(u=>u.Id==id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category category = _db.categoryRepository.get(u => u.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.categoryRepository.get(u => u.Id == id);
            if (obj == null)
                return NotFound();

            _db.categoryRepository.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }

    }
}
