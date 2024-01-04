namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keytoWuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionSLNO", "dbo.Questions");
            DropPrimaryKey("dbo.Questions");
            AddColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Questions", "QuestionId");
            AddForeignKey("dbo.Answers", "QuestionSLNO", "dbo.Questions", "QuestionId", cascadeDelete: true);
            DropColumn("dbo.Questions", "SLNO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "SLNO", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Answers", "QuestionSLNO", "dbo.Questions");
            DropPrimaryKey("dbo.Questions");
            DropColumn("dbo.Questions", "QuestionId");
            AddPrimaryKey("dbo.Questions", "SLNO");
            AddForeignKey("dbo.Answers", "QuestionSLNO", "dbo.Questions", "SLNO", cascadeDelete: true);
        }
    }
}
