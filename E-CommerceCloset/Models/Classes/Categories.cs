using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class Categories
    {
        [Key]
        
        public int CategoriesID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
      
    }
}