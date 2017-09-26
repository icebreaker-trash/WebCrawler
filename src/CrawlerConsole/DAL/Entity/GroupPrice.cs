namespace CrawlerConsole.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupPrice
    {
        [Key]
        public Guid Id { get; set; }


        public Guid Lineid { get; set; }


        public string GroupDate { get; set; }


        public double AdultPrice { get; set; }


        public double ChildPrice { get; set; }

        [ForeignKey(nameof(Lineid))]
        public virtual Line Line { get; set; }
    }
}
