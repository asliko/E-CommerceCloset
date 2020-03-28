using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_CommerceCloset.Models;
using E_CommerceCloset.Models.Classes;
using E_CommerceCloset.Models.ViewModel;

namespace E_CommerceCloset.Controllers
{
    public class ProductsController : Controller
    {
        private ClosetContext db = new ClosetContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = (from a in db.Products
                           select new CategorySizeViewModel
                           {
                               ProductID=a.ProductID,
                               CategoriesID = a.CategoriesID,
                               GenderID=a.GenderID,
                               SizeID = a.SizeID,
                               ProductType = a.ProductType,
                               Name = a.Name,
                               Brand = a.Brand,
                               Description = a.Description,
                               Price = a.Price,
                               Color = a.Color,
                               Tax = a.Tax,
                               Discount = a.Discount,
                               Stock = a.Stock,
                               IsActive = a.IsActive,
                           }).ToList();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoriesID = new SelectList(db.Categories, "CategoriesID", "CategoryName");
        //    ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeName");
        //    return View();
        //}

        public ActionResult Create()
        {


            CategorySizeViewModel model = new CategorySizeViewModel();


            List<Categories> CategoriesList = db.Categories.OrderBy(f => f.CategoryName).ToList();

            model.CategoriesList = (from s in CategoriesList
                                    select new SelectListItem
                                    {
                                        Text = s.CategoryName,
                                        Value = s.CategoriesID.ToString()
                                    }).ToList();
            model.CategoriesList.Insert(0, new SelectListItem { Value = "", Text = "Seçiniz", Selected = true });


            List<Gender> GenderList = db.Genders.OrderBy(f => f.GenderName).ToList();

            model.GenderList = (from n in GenderList
                                    select new SelectListItem
                                    {
                                        Text = n.GenderName,
                                        Value = n.GenderID.ToString()
                                    }).ToList();
            model.GenderList.Insert(0, new SelectListItem { Value = "", Text = "Seçiniz", Selected = true });


            return View(model);
        }

        public JsonResult SizeList(int id)
        {
            ClosetContext db = new ClosetContext();
            List<Size> sizelist = db.Sizes.Where(f => f.CategoriesID == id).OrderBy(f => f.SizeName).ToList();

            List<SelectListItem> itemlist = (from i in sizelist
                                             select new SelectListItem
                                             {
                                                 Value = i.SizeID.ToString(),
                                                 Text = i.SizeName
                                             }).ToList();

            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }


        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategorySizeViewModel model)/*[Bind(Include = "ProductID,ProductType,Name,Brand,CategoriesID,ImageUrl,Description,Price,Color,Tax,Discount,Stock,IsActive,SizeID")] Product product*/
        {
            Product p = new Product();
            if (ModelState.IsValid) {
                if (model.Image != null && model.Image.ContentLength > 0)
                {
                    string extension = Path.GetExtension(model.Image.FileName).ToLower();
                    string File = Guid.NewGuid().ToString();
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        ModelState.AddModelError("Image", "The File Extension Must be Jpg,Png,JPeg");
                        return View(model);
                    }
                    string fileName = File + extension;
                    model.Image.SaveAs(Server.MapPath("~/Content/productPhoto/" + fileName));
                    p.Image = fileName;


                    List<Categories> CategoriesList = db.Categories.OrderBy(f => f.CategoryName).ToList();

                    model.CategoriesList = (from s in CategoriesList
                                            select new SelectListItem
                                            {
                                                Text = s.CategoryName,
                                                Value = s.CategoriesID.ToString()
                                            }).ToList();
                    model.CategoriesList.Insert(0, new SelectListItem { Value = "", Text = "Seçiniz", Selected = true });



                    p.CategoriesID = model.CategoriesID;
                    p.SizeID = model.SizeID;
                    p.ProductType = model.ProductType;
                    p.Name = model.Name;
                    p.Brand = model.Brand;
                    p.Description = model.Description;
                    p.Price = model.Price;
                    p.Color = model.Color;
                    p.Tax = model.Tax;
                    p.Discount = model.Discount;
                    p.Stock = model.Stock;
                    p.GenderID = model.GenderID;
                    p.IsActive = model.IsActive;
                    db.Products.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index","Products");
                   

                }


            }

          
    return RedirectToAction("Index","Product");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "CategoriesID", "CategoryName", product.CategoriesID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeName", product.SizeID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductType,Name,Brand,CategoriesID,ImageUrl,Description,Price,Color,Tax,Discount,Stock,IsActive,SizeID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "CategoriesID", "CategoryName", product.CategoriesID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeName", product.SizeID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
      

    }
}
