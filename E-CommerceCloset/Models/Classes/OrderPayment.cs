using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class OrderPayment
    {
        [Key]

        public int OrderPaymentID { get; set; }
        public int OrderID { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }
        public Order Order { get; set; }


    }
    public enum _OrderType
    {
        Havale = 0,
        KrediKarti = 1,
    }
}
