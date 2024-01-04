namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policies", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Policies", new[] { "CustomerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Policies", "CustomerId");
            AddForeignKey("dbo.Policies", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
