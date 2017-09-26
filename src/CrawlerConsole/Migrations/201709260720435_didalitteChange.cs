namespace CrawlerConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class didalitteChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "ArriveCity", c => c.String());
            AddColumn("dbo.Lines", "Url", c => c.String());
            AddColumn("dbo.Lines", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GroupPrices", "GroupDate", c => c.String());
            AlterColumn("dbo.Lines", "SiteName", c => c.String());
            AlterColumn("dbo.Lines", "TypeName", c => c.String());
            AlterColumn("dbo.Lines", "Departcity", c => c.String());
            AlterColumn("dbo.Lines", "Port", c => c.String());
            AlterColumn("dbo.Lines", "Linetitle", c => c.String());
            AlterColumn("dbo.Lines", "Days", c => c.String());
            AlterColumn("dbo.Lines", "Scenic", c => c.String());
            AlterColumn("dbo.Lines", "Journey", c => c.String());
            AlterColumn("dbo.Lines", "Hotels", c => c.String());
            AlterColumn("dbo.Lines", "Supplier", c => c.String());
            AlterColumn("dbo.Lines", "Traffic", c => c.String());
            AlterColumn("dbo.Lines", "Trafficdetail", c => c.String());
            AlterColumn("dbo.Lines", "Reco", c => c.String());
            AlterColumn("dbo.Lines", "CommentNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Lines", "PmRecommendation", c => c.String());
            DropColumn("dbo.Lines", "Descity");
            DropColumn("dbo.Lines", "Durl");
            DropColumn("dbo.Lines", "Cdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lines", "Cdate", c => c.String(maxLength: 50));
            AddColumn("dbo.Lines", "Durl", c => c.String(maxLength: 500));
            AddColumn("dbo.Lines", "Descity", c => c.String(maxLength: 100));
            AlterColumn("dbo.Lines", "PmRecommendation", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Lines", "CommentNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Lines", "Reco", c => c.String(maxLength: 100));
            AlterColumn("dbo.Lines", "Trafficdetail", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Lines", "Traffic", c => c.String(maxLength: 100));
            AlterColumn("dbo.Lines", "Supplier", c => c.String(maxLength: 500));
            AlterColumn("dbo.Lines", "Hotels", c => c.String(maxLength: 500));
            AlterColumn("dbo.Lines", "Journey", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Lines", "Scenic", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Lines", "Days", c => c.String(maxLength: 50));
            AlterColumn("dbo.Lines", "Linetitle", c => c.String(maxLength: 500));
            AlterColumn("dbo.Lines", "Port", c => c.String(maxLength: 100));
            AlterColumn("dbo.Lines", "Departcity", c => c.String(maxLength: 100));
            AlterColumn("dbo.Lines", "TypeName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Lines", "SiteName", c => c.String(maxLength: 50));
            AlterColumn("dbo.GroupPrices", "GroupDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lines", "CreateDate");
            DropColumn("dbo.Lines", "Url");
            DropColumn("dbo.Lines", "ArriveCity");
        }
    }
}
