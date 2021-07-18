namespace Jiraiya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFieldsInProjectIssueAndSprint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Issues", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Sprints", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Sprints", "ActualEndDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ActualEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ActualEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Sprints", "ActualEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Sprints", "Name", c => c.String());
            AlterColumn("dbo.Issues", "Name", c => c.String());
        }
    }
}
