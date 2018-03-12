namespace FashionPlatform.Domain.Migrations.MigrationProduct
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletTestPropfromProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Temp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Temp", c => c.String());
        }
    }
}
