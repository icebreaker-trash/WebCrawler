using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerConsole.DAL.Entity
{
    public class ArriveCity
    {
        //[Key]
        public string CityName { get; set; }

        public string CityCode { get; set; }
    }

    public class ArriveCityConfig: EntityTypeConfiguration<ArriveCity>
    {
        public ArriveCityConfig()
        {
            HasKey(t => t.CityName);
        }
    }
}
