using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaughtFromTuniu
{
    public class ArriveCityEntity
    {
        private string cityName = string.Empty;

        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        private int cityCode = 0;

        public int CityCode
        {
            get { return cityCode; }
            set { cityCode = value; }
        }
    }
}