using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public Userr User { get; set; }
        public int UserAddressID { get; set; }
        public UserAddress UserAddress { get; set; }
        //public DateTime CreateDate { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public decimal TotatlProductPrice { get; set; }
        public decimal TotalTaxPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}