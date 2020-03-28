using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }
       
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
       
    }
}