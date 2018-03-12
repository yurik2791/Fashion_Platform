namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToUsers9 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.AspNetUsers", "Age");
            //DropColumn("dbo.AspNetUsers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
    }
}
