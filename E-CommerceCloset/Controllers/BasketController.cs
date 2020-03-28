using E_CommerceCloset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceCloset.Controllers
{
    public class BasketController : HomeController
    {
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int productID, int quantity)
        {
            var db = new ClosetContext();
            db.Baskets.Add(new Models.Classes.Basket 
            {
                
              
                ProductID = productID,
                Quantity = quantity,
                UserID = LoginUserID

            });
            var rt = db.SaveChanges();
            return Json(rt, JsonRequestBehavior.AllowGet);
        }

       


      
        public ActionResult Cart()
        {
            var db = new ClosetContext();
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID);
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new ClosetContext();
            var deleteitem = db.Baskets.Where(x => x.BasketID == id).FirstOrDefault();
            db.Baskets.Remove(deleteitem);
            db.SaveChanges();
            return RedirectToAction("Cart");

        }
    }

  
    
}
