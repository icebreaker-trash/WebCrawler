namespace CrawlerConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupPrices", "Lineid", "dbo.Lines");
            DropIndex("dbo.GroupPrices", new[] { "Lineid" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.GroupPrices", "Lineid");
            AddForeignKey("dbo.GroupPrices", "Lineid", "dbo.Lines", "Id", cascadeDelete: true);
        }
    }
}
