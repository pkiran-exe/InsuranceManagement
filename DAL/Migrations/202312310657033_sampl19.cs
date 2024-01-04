namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sampl19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policies", "PolicyHolder_Id", "dbo.Customers");
            DropIndex("dbo.Policies", new[] { "PolicyHolder_Id" });
            DropColumn("dbo.Policies", "PolicyHolder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Policies", "PolicyHolder_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Policies", "PolicyHolder_Id");
            AddForeignKey("dbo.Policies", "PolicyHolder_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
