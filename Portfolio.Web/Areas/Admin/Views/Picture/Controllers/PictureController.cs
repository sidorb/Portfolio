using Portfolio.Domain;
using Portfolio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Web.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        private IPortfolioDataSource db;

        public PictureController(IPortfolioDataSource db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                Picture picture = new Picture
                {
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId,
                    Description = model.Description
                };

                db.AddPicture(picture);

                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
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
            db.DeletePicture(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Picture picture = db.Pictures.Single(c => c.PictureId == id);
            PictureViewModel model = new PictureViewModel
            {
                PictureId = picture.PictureId,
                ImageUrl = picture.ImageUrl,
                Description = picture.Description,
                CategoryId = picture.CategoryId
            };
            
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "Name", selectedValue:picture.CategoryId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                Picture picture = new Picture
                {
                    PictureId = model.PictureId,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };
                db.AddPicture(picture);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "Name");
            return View(model);
        }

    }
}
