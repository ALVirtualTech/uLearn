namespace uLearn.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizStatisticsIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserQuizs", new[] { "SlideId" });
            CreateIndex("dbo.UserQuizs", new[] { "SlideId", "Timestamp" }, name: "StatisticsIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserQuizs", "StatisticsIndex");
            CreateIndex("dbo.UserQuizs", "SlideId");
        }
    }
}
