namespace FashionPlatform.Domain.Migrations.MigrationProduct
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNullableId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CountryId", c => c.Int());
            AlterColumn("dbo.Products", "ShoeId", c => c.Int());
            AlterColumn("dbo.Products", "UpWearId", c => c.Int());
            AlterColumn("dbo.Products", "DownWearId", c => c.Int());
            AlterColumn("dbo.Products", "AccessoryId", c => c.Int());
            AlterColumn("dbo.Products", "ProductDestinasionId", c => c.Int());
            AlterColumn("dbo.Products", "FiberId", c => c.Int());
            AlterColumn("dbo.Products", "ClothId", c => c.Int());
            AlterColumn("dbo.Products", "StyleId", c => c.Int());
            AlterColumn("dbo.Products", "DressCodeId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DressCodeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "StyleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ClothId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "FiberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductDestinasionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "AccessoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DownWearId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "UpWearId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ShoeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CountryId", c => c.Int(nullable: false));
        }
    }
}
