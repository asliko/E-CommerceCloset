using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class Size
    {
        [Key]

        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public int CategoriesID { get; set; }
        public  Categories Categories { get; set; }

       
    }
}