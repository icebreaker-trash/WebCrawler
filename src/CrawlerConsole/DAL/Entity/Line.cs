using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrawlerConsole.DAL.Entity
{
    public partial class Line
    {
        [Key]
        public Guid Id { get; set; }



        [StringLength(50)]
        public string SiteName { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(100)]
        public string Departcity { get; set; }

        [StringLength(100)]
        public string Descity { get; set; }

        [StringLength(100)]
        public string Port { get; set; }

        [StringLength(500)]
        public string Linetitle { get; set; }

        [StringLength(50)]
        public string Days { get; set; }

        [StringLength(4000)]
        public string Scenic { get; set; }

        [StringLength(2000)]
        public string Journey { get; set; }

        [StringLength(500)]
        public string Hotels { get; set; }

        [StringLength(500)]
        public string Supplier { get; set; }

        [StringLength(100)]
        public string Traffic { get; set; }

        [StringLength(1000)]
        public string Trafficdetail { get; set; }

        public int? Soldqty { get; set; }

        [StringLength(500)]
        public string Durl { get; set; }

        [StringLength(100)]
        public string Reco { get; set; }

        [StringLength(50)]
        public string Cdate { get; set; }

        [StringLength(50)]
        public string CommentNumber { get; set; }

        [StringLength(4000)]
        public string PmRecommendation { get; set; }

        
        public virtual ICollection<GroupPrice> GroupPrices { get; set; }
    }
}
