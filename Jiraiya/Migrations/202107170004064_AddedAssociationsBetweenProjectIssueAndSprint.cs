namespace Jiraiya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssociationsBetweenProjectIssueAndSprint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Issues", new[] { "Sprint_Id" });
            DropIndex("dbo.Sprints", new[] { "Project_Id" });
            AlterColumn("dbo.Issues", "Sprint_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Sprints", "Project_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "Sprint_Id");
            CreateIndex("dbo.Sprints", "Project_Id");
            AddForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints");
            DropIndex("dbo.Sprints", new[] { "Project_Id" });
            DropIndex("dbo.Issues", new[] { "Sprint_Id" });
            AlterColumn("dbo.Sprints", "Project_Id", c => c.Int());
            AlterColumn("dbo.Issues", "Sprint_Id", c => c.Int());
            CreateIndex("dbo.Sprints", "Project_Id");
            CreateIndex("dbo.Issues", "Sprint_Id");
            AddForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints", "Id");
        }
    }
}
