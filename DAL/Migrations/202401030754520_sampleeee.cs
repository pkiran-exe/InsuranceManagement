namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sampleeee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "CustomerId");
        }
    }
}
