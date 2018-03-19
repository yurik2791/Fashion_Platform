namespace FashionPlatform.Domain.Migrations.MigrationProduct
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableForAllEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        TypeClothId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DownWears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DressCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fibers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        TypeFiberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDestinasions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeCloths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeFibers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpWears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ShoeId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UpWearId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DownWearId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "AccessoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductDestinasionId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "FiberId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ClothId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "StyleId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DressCodeId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Country");
            DropColumn("dbo.Products", "Shoe");
            DropColumn("dbo.Products", "UpWear");
            DropColumn("dbo.Products", "DownWear");
            DropColumn("dbo.Products", "Accessory");
            DropColumn("dbo.Products", "ProductDestinasion");
            DropColumn("dbo.Products", "Fiber");
            DropColumn("dbo.Products", "Cloth");
            DropColumn("dbo.Products", "Style");
            DropColumn("dbo.Products", "DressCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DressCode", c => c.String());
            AddColumn("dbo.Products", "Style", c => c.String());
            AddColumn("dbo.Products", "Cloth", c => c.String());
            AddColumn("dbo.Products", "Fiber", c => c.String());
            AddColumn("dbo.Products", "ProductDestinasion", c => c.String());
            AddColumn("dbo.Products", "Accessory", c => c.String());
            AddColumn("dbo.Products", "DownWear", c => c.String());
            AddColumn("dbo.Products", "UpWear", c => c.String());
            AddColumn("dbo.Products", "Shoe", c => c.String());
            AddColumn("dbo.Products", "Country", c => c.String());
            DropColumn("dbo.Products", "DressCodeId");
            DropColumn("dbo.Products", "StyleId");
            DropColumn("dbo.Products", "ClothId");
            DropColumn("dbo.Products", "FiberId");
            DropColumn("dbo.Products", "ProductDestinasionId");
            DropColumn("dbo.Products", "AccessoryId");
            DropColumn("dbo.Products", "DownWearId");
            DropColumn("dbo.Products", "UpWearId");
            DropColumn("dbo.Products", "ShoeId");
            DropColumn("dbo.Products", "CountryId");
            DropTable("dbo.UpWears");
            DropTable("dbo.TypeFibers");
            DropTable("dbo.TypeCloths");
            DropTable("dbo.Styles");
            DropTable("dbo.Shoes");
            DropTable("dbo.ProductDestinasions");
            DropTable("dbo.Fibers");
            DropTable("dbo.DressCodes");
            DropTable("dbo.DownWears");
            DropTable("dbo.Countries");
            DropTable("dbo.Clothes");
            DropTable("dbo.Accessories");
        }
    }
}
