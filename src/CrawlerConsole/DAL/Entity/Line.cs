using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrawlerConsole.DAL.Entity
{
    public partial class Line
    {
        [Key]
        public Guid Id { get; set; }

        public string SiteName { get; set; }

        public string TypeName { get; set; }

        public string Departcity { get; set; }

        public string ArriveCity { get; set; }

        public string Port { get; set; }

        public string Linetitle { get; set; }

        public string Days { get; set; }

        public string Scenic { get; set; }

        public string Journey { get; set; }

        public string Hotels { get; set; }

        public string Supplier { get; set; }

        public string Traffic { get; set; }

        public string Trafficdetail { get; set; }

        public int? Soldqty { get; set; }

        public string Url { get; set; }

        public string Reco { get; set; }

        public DateTime CreateDate { get; set; }

        public int CommentNumber { get; set; }

        public string PmRecommendation { get; set; }

        public virtual ICollection<GroupPrice> GroupPrices { get; set; }
    }
}
