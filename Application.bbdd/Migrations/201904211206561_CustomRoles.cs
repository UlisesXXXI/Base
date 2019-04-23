namespace Application.bbdd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Active");
        }
    }
}
