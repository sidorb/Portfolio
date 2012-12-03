using Portfolio.Domain;
using Portfolio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private IPortfolioDataSource db;

        public CategoryController(IPortfolioDataSource db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category { Name = model.Name };
                db.AddCategory(category);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id) 
        {
            return View(id);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteCategory(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = db.Categories.Single(c => c.CategoryId == id);
            CategoryViewModel model = new CategoryViewModel { Id = id, Name = category.Name };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category { Name = model.Name, CategoryId = model.Id };
                db.AddCategory(category);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}