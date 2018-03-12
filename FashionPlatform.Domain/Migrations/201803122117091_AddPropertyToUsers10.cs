namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToUsers10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Year", c => c.Int(nullable: false));
        }
    }
}
