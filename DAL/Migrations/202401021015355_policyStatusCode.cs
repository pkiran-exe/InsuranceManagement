namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class policyStatusCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppliedPolicies", "StatusCode", c => c.Int(nullable: false));
            DropColumn("dbo.AppliedPolicies", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppliedPolicies", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.AppliedPolicies", "StatusCode");
        }
    }
}
