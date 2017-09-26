namespace CrawlerConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupPrices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Lineid = c.Guid(nullable: false),
                        GroupDate = c.DateTime(nullable: false),
                        AdultPrice = c.Double(nullable: false),
                        ChildPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lines", t => t.Lineid, cascadeDelete: true)
                .Index(t => t.Lineid);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SiteName = c.String(maxLength: 50),
                        TypeName = c.String(maxLength: 50),
                        Departcity = c.String(maxLength: 100),
                        Descity = c.String(maxLength: 100),
                        Port = c.String(maxLength: 100),
                        Linetitle = c.String(maxLength: 500),
                        Days = c.String(maxLength: 50),
                        Scenic = c.String(maxLength: 4000),
                        Journey = c.String(maxLength: 2000),
                        Hotels = c.String(maxLength: 500),
                        Supplier = c.String(maxLength: 500),
                        Traffic = c.String(maxLength: 100),
                        Trafficdetail = c.String(maxLength: 1000),
                        Soldqty = c.Int(),
                        Durl = c.String(maxLength: 500),
                        Reco = c.String(maxLength: 100),
                        Cdate = c.String(maxLength: 50),
                        CommentNumber = c.String(maxLength: 50),
                        PmRecommendation = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupPrices", "Lineid", "dbo.Lines");
            DropIndex("dbo.GroupPrices", new[] { "Lineid" });
            DropTable("dbo.Lines");
            DropTable("dbo.GroupPrices");
        }
    }
}
