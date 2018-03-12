namespace FashionPlatform.Domain.Migrations.MigrationProduct
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestPropertyToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Temp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Temp");
        }
    }
}
