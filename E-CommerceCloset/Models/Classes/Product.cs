using System.ComponentModel.DataAnnotations;


namespace E_CommerceCloset.Models.Classes
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int CategoriesID { get; set; }
        public Categories Categories { get; set; }         
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public Order Order { get; set; }
        public int SizeID { get; set; }
        public virtual Size Size { get; set; }
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }


    }
}