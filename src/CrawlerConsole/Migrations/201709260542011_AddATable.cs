namespace CrawlerConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddATable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArriveCities",
                c => new
                    {
                        CityName = c.String(nullable: false, maxLength: 128),
                        CityCode = c.String(),
                    })
                .PrimaryKey(t => t.CityName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArriveCities");
        }
    }
}
