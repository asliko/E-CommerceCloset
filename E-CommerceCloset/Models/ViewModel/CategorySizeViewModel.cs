using E_CommerceCloset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace E_CommerceCloset.Models.ViewModel
{
    public class CategorySizeViewModel
    {
        public CategorySizeViewModel()
        {
            this.SizeList = new List<SelectListItem>();
            SizeList.Add(new SelectListItem { Text = "Seçiniz", Value = "" });
        }
        public int CategoriesID { get; set; }
        public int SizeID { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public List<SelectListItem> SizeList { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SizeName { get; set; }
        public string GenderName { get; set; }       
        public string Brand { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Image2 { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Categories> Categories { get; set; }         
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }
    }
}