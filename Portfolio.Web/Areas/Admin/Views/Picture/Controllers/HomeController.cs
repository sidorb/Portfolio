using Portfolio.Domain;
using Portfolio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IPortfolioDataSource db;

        public HomeController(IPortfolioDataSource db)
        {
            this.db = db;
        }

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Category(int id)
        {
            var pictures = db.Pictures.Where(p => p.CategoryId == id).ToList();
            return View(pictures);
        }

    }
}
