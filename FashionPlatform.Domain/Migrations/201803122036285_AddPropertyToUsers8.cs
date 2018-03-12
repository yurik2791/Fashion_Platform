namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToUsers8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetRoles", "n");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "n", c => c.String());
        }
    }
}
