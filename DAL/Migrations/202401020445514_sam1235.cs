namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sam1235 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        QuestionSLNO = c.Int(nullable: false),
                        AnswerText = c.String(maxLength: 255),
                        AnswerDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionSLNO, cascadeDelete: true)
                .Index(t => t.QuestionSLNO);
            
            CreateTable(
                "dbo.AppliedPolicies",
                c => new
                    {
                        AppliedPolicyId = c.Int(nullable: false, identity: true),
                        PolicyNumber = c.String(nullable: false),
                        AppliedDate = c.DateTime(nullable: false),
                        Category = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppliedPolicyId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppliedPolicies", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Answers", "QuestionSLNO", "dbo.Questions");
            DropIndex("dbo.AppliedPolicies", new[] { "CustomerId" });
            DropIndex("dbo.Answers", new[] { "QuestionSLNO" });
            DropTable("dbo.AppliedPolicies");
            DropTable("dbo.Answers");
        }
    }
}
