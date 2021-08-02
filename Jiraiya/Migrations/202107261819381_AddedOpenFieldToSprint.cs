namespace Jiraiya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOpenFieldToSprint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sprints", "Open", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sprints", "Open");
        }
    }
}
