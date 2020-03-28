using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceCloset.Models.Classes
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}