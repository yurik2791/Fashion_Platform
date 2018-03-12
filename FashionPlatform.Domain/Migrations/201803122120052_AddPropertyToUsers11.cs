namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToUsers11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
