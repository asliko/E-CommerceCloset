using E_CommerceCloset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceCloset.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        
        public ActionResult Index(string isim, int id)
        {
            var db = new ClosetContext();
            var data = db.Products.Where(x => x.IsActive == true && x.CategoriesID == id).ToList();
            ViewBag.category = db.Categories.Where(x => x.CategoriesID == id).FirstOrDefault();
            return View(data);
        }
    }
}