namespace WebTechnologyHomeworkBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(maxLength: 60),
                        ArticleGenre = c.String(nullable: false, maxLength: 30),
                        ArticleTitle = c.String(),
                        ArticleContent = c.String(),
                        AuthorName = c.String(),
                        CommentContent = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Article_ArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleID)
                .Index(t => t.Article_ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Article_ArticleID", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "Article_ArticleID" });
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
