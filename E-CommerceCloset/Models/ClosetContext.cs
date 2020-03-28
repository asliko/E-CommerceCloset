using E_CommerceCloset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models
{
    public class ClosetContext:DbContext
    {
      
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Categories> Categories { get; set; }       
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Userr> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Gender> Genders { get; set; }



    }
}