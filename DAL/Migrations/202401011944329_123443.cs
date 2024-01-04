namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123443 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policies", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Policies", "CustomerId");

        }
        
        public override void Down()
        {
            DropIndex("dbo.Policies", new[] { "CustomerId" });
            DropColumn("dbo.Policies", "CustomerId");
        }
    }
}
