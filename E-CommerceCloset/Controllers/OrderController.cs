using E_CommerceCloset.Models;
using E_CommerceCloset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceCloset.Controllers
{
    public class OrderController :HomeController
    {
        // GET: Order
        [Route("Siparisver")]
        public ActionResult AdressList()
        {
            var db = new ClosetContext();
            var data = db.UserAddresses.Where(x => x.UserID == LoginUserID).ToList();

            return View(data);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {
           
            entity.IsActive = true;
            entity.UserID = LoginUserID;

            var db = new ClosetContext();
            db.UserAddresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AdressList");

        }
        public ActionResult CreateOrder(int id)
        {
            var db = new ClosetContext();

            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            Order order = new Order();
            order.StatusID = 2;
            order.TotatlProductPrice = sepet.Sum(x => x.Product.Price);
            order.TotatlProductPrice = sepet.Sum(x => x.Product.Tax);
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotatlProductPrice + order.TotalTaxPrice;
            order.UserAddressID = id;
            order.UserID = LoginUserID;
          
        
            db.Orders.Add(order);
            db.SaveChanges();
            var orderid = order.OrderID;

            return RedirectToAction("Detail", new { id = order.OrderID });
        }
        public ActionResult Detail(int id)
        {
            var db = new ClosetContext();
            var data = db.Orders.Include("OrderPayments")
                .Include("Status")
                .Include("UserAddress")
                .Where(x => x.OrderID == id).FirstOrDefault();
            return View(data);

        }
        [Route("Siparişlerim")]
        public ActionResult Indexx()
        {
            var db = new ClosetContext();
            var data = db.Orders.Include("Status").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Pay(int id)
        {
            var db = new ClosetContext();
            var order = db.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            order.StatusID = 8;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.OrderID });
        }



    }
}