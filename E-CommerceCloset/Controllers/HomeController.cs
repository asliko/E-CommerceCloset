using E_CommerceCloset.Models;
using E_CommerceCloset.Models.Classes;
using E_CommerceCloset.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_CommerceCloset.Controllers
{
    public class HomeController : Controller
    {
        ClosetContext db = new ClosetContext();
        public ActionResult Index()
        {
           ViewBag.gender = (from p in db.Genders select new { p.GenderID,p.GenderName}).ToList();
            return View();
        }
        public ActionResult Anasayfa()
        {
           
            return View();
        }


        public ActionResult ProductDetail()
        {
           


                var liste2 = (from c in db.Products
                             
                              select new CategorySizeViewModel
                              {
                                  ProductID = c.ProductID,
                                  Image2 = c.Image,
                                  Price = c.Price,
                                  CategoryName = c.Categories.CategoryName,
                                  Name = c.Name,
                                  Description = c.Description,
                                  CategoriesID = c.CategoriesID,
                                  GenderName = c.Gender.GenderName,
                                  SizeName = c.Size.SizeName
                              });
                return View(liste2);
            }
        


public ActionResult Products(int? id)
        {
      
            if (id==null)
            {
                var liste = (from c in db.Products
                         select new CategorySizeViewModel
                         {
                             ProductID=c.ProductID,
                             Image2=c.Image,
                             Price=c.Price,
                             CategoryName=c.Categories.CategoryName,
                             Name=c.Name,
                             Description=c.Description,
                             CategoriesID=c.CategoriesID,
                             GenderID=c.GenderID
                             
                         });
                return PartialView(liste);
            }
            else
            {
                
  
                 
                var liste2= (from c in db.Products where c.GenderID==id
                            select new CategorySizeViewModel
                            {
                                ProductID = c.ProductID,
                                Image2 = c.Image,
                                Price = c.Price,
                                CategoryName = c.Categories.CategoryName,
                                Name = c.Name,
                                Description = c.Description,
                                CategoriesID = c.CategoriesID,
                                GenderID = c.GenderID

                            });
                return PartialView("Product",liste2);
            }
           
           
        }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    

        [HttpPost]
        public ActionResult Search(string valu)
        {
            List<Product> products = db.Products.Where(s => s.ProductType.Contains(valu) || s.Name.Contains(valu) || s.Brand.Contains(valu)).ToList();
            if (products.Count == 0)
            {
                ViewBag.NoRecord = "No Item Found";
            }
            else
            {
                ViewBag.NoRecord = products.Count + "  Item Found";
            }
            ViewBag.val = valu;
            return View(products);
        }

        public ActionResult SignIn(string returnUrl)
        {

            ViewBag.returnUrl = returnUrl;
            return View();


        }
        [HttpPost]
        public ActionResult SignIn(UserModel model, string returnUrl)

        {
            Userr User = db.Users.Where(s => s.Email == model.Email && s.Password == model.Password).SingleOrDefault();
            if (User != null)
            {
                Session["UserSession"] = true;
                Session["UserId"] = User.UserID;
                Session["UserUname"] = User.Email;
                Session["UserAdmin"] = User.IsAdmin;
                Session["UserImage"] = User.ImagePath;

                if (returnUrl == null)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return Redirect(returnUrl);
                }



            }
            else
            {
                ViewBag.Error = "User Name And Password is Required";
                return View();
            }


        }

        public ActionResult SignOut(string returnUrl)
        {
            Session.Abandon();
            return Redirect(returnUrl);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            if (db.Users.Where(s => s.Email == model.Email).Count() > 0)

            {
                ViewBag.Error = "Username registered";
                return View();
            }

            Userr neww = new Userr();
            if (model.ImagePath != null && model.ImagePath.ContentLength > 0)
            {
              
                string extension = Path.GetExtension(model.ImagePath.FileName).ToLower();
                string file = Guid.NewGuid().ToString();
                if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                {
                    ModelState.AddModelError("ImagePath", "The file extension must be JPG,JPEG or PNG");
                    return View(model);
                }
                string fileName = file + extension;
                model.ImagePath.SaveAs(Server.MapPath("~/Content/userPhoto/" + fileName));
                neww.ImagePath = fileName;
            }
            neww.Name= model.Name;
            neww.LastName= model.LastName;
            neww.Email = model.Email;          
            neww.Password = model.Password;

            db.Users.Add(neww);
            db.SaveChanges();




            Userr User = db.Users.OrderByDescending(s => s.UserID).FirstOrDefault();
            Session["UserSession"] = true;
            Session["UserId"] = User.UserID;
            Session["UserName"] = User.Name;
            Session["UserAdmin"] = User.IsAdmin;
            Session["UserImage"] = User.ImagePath;
            return RedirectToAction("Index");
        }

        public bool Islogin { get; private set; }
        /// <summary>
        /// Giriş Yapmış Kisinin IDsi
        /// </summary>
        public int LoginUserID { get; set; }
        /// <summary>
        /// Login User Entity
        /// </summary>
        public Userr LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUserID"] 
            //Session["LoginUser"]
            if (requestContext.HttpContext.Session["LoginUserID"] != null)
            {
                //Kullanıcı Giriş Yapmış
                Islogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (E_CommerceCloset.Models.Classes.Userr
                    )requestContext.HttpContext.Session["LoginUser"];

            }

            base.Initialize(requestContext);
        }





    }

    
}