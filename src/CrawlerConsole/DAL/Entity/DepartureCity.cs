using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerConsole.DAL.Entity
{
    public class DepartureCity
    {
        [Key]
        public string CityName { get; set; }

        [Description("缩写")]
        public string Abbreviation { get; set; }

        public string CityCode { get; set; }
    }
}
