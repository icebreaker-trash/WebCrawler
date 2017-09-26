using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaughtFromTuniu
{
    public class ParseJson
    {
        public int code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Calendarinfo[] calendarInfo { get; set; }
        public string childrenPriceTip { get; set; }
        public int proMode { get; set; }
        public Promotionlist[] promotionList { get; set; }
        public int defaultAdultNum { get; set; }
        public int defaultChildNum { get; set; }
        public int defaultFreeChildNum { get; set; }
        public string freeChildPriceTip { get; set; }
    }

    public class Calendarinfo
    {
        public int startPrice { get; set; }
        public int adultPrice { get; set; }
        public int excludeChildFlag { get; set; }
        public int childPrice { get; set; }
        public int freeChildPrice { get; set; }
        public object roomGrapFlag { get; set; }
        public int flightTicketType { get; set; }
        public int strategyType { get; set; }
        public int bookCityCode { get; set; }
        public string departureCityCode { get; set; }
        public int discount { get; set; }
        public object discountDesc { get; set; }
        public string promotionIntro { get; set; }
        public string lowestPriceName { get; set; }
        public int mobileOnlyFlag { get; set; }
        public int sharingPromotionId { get; set; }
        public int sharingPreferential { get; set; }
        public Stockinfo stockInfo { get; set; }
        public string weekDay { get; set; }
        public int isRealTimePrice { get; set; }
        public int vendorId { get; set; }
        public object resId { get; set; }
        public string realTimeTips { get; set; }
        public object cutPrice { get; set; }
        public object maxCoupon { get; set; }
        public string planDate { get; set; }
        public string planWeek { get; set; }
    }

    public class Stockinfo
    {
        public int stockSign { get; set; }
        public int? stockNum { get; set; }
    }

    public class Promotionlist
    {
        public string promotionName { get; set; }
        public int themeId { get; set; }
        public int type { get; set; }
        public string tagName { get; set; }
        public string tagColor { get; set; }
        public string activityTitle { get; set; }
        public string activityDate { get; set; }
        public string activityContent { get; set; }
        public int discountPrice { get; set; }
        public object[] planDates { get; set; }
        public Plandatesforpc planDatesForPc { get; set; }
        public int isToStart { get; set; }
    }

    public class Plandatesforpc
    {
    }

}