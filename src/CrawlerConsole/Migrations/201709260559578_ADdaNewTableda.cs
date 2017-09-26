namespace CrawlerConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADdaNewTableda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartureCities",
                c => new
                    {
                        CityName = c.String(nullable: false, maxLength: 128),
                        Abbreviation = c.String(),
                        CityCode = c.String(),
                    })
                .PrimaryKey(t => t.CityName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DepartureCities");
        }
    }
}
