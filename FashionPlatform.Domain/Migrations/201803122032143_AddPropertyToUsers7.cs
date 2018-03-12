namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToUsers7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "n", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "n");
        }
    }
}
