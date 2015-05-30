namespace WebTechnologyHomeworkBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class articleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "articleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "articleName");
        }
    }
}
