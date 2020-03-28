using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.Classes
{
    public class UserAddress
    {
        
       [Key]
        public int UserAddressID { get; set; }
        public int UserID { get; set; }
        public virtual Userr User { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }


    }
}