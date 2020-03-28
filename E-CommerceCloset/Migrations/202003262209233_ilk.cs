namespace E_CommerceCloset.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductType = c.String(),
                        Name = c.String(),
                        Brand = c.String(),
                        CategoriesID = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SizeID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoriesID, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .ForeignKey("dbo.Sizes", t => t.SizeID, cascadeDelete: true)
                .Index(t => t.CategoriesID)
                .Index(t => t.SizeID)
                .Index(t => t.GenderID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoriesID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoriesID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        SizeName = c.String(),
                        CategoriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SizeID)
                .ForeignKey("dbo.Categories", t => t.CategoriesID, cascadeDelete: false)
                .Index(t => t.CategoriesID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserAddressID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        TotatlProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTaxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Userrs", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserAddresses", t => t.UserAddressID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.UserAddressID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.OrderPayments",
                c => new
                    {
                        OrderPaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        OrderType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.OrderPaymentID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Userrs",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Password = c.String(),
                        TCKN = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserAddressID)
                .ForeignKey("dbo.Userrs", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.Orders", "UserAddressID", "dbo.UserAddresses");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Userrs");
            DropForeignKey("dbo.UserAddresses", "UserID", "dbo.Userrs");
            DropForeignKey("dbo.Orders", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderPayments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Products", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Products", "CategoriesID", "dbo.Categories");
            DropForeignKey("dbo.Sizes", "CategoriesID", "dbo.Categories");
            DropIndex("dbo.UserAddresses", new[] { "UserID" });
            DropIndex("dbo.OrderPayments", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "StatusID" });
            DropIndex("dbo.Orders", new[] { "UserAddressID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Sizes", new[] { "CategoriesID" });
            DropIndex("dbo.Products", new[] { "Order_OrderID" });
            DropIndex("dbo.Products", new[] { "GenderID" });
            DropIndex("dbo.Products", new[] { "SizeID" });
            DropIndex("dbo.Products", new[] { "CategoriesID" });
            DropIndex("dbo.Baskets", new[] { "ProductID" });
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Userrs");
            DropTable("dbo.Status");
            DropTable("dbo.OrderPayments");
            DropTable("dbo.Orders");
            DropTable("dbo.Genders");
            DropTable("dbo.Sizes");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Baskets");
        }
    }
}
