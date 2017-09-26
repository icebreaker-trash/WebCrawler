using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrawlerConsole
{
    public class ParseJson
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public Calendarinfo[] CalendarInfo { get; set; }
        public string ChildrenPriceTip { get; set; }
        public int ProMode { get; set; }
        public Promotionlist[] PromotionList { get; set; }
        public int DefaultAdultNum { get; set; }
        public int DefaultChildNum { get; set; }
        public int DefaultFreeChildNum { get; set; }
        public string FreeChildPriceTip { get; set; }
    }

    public class Calendarinfo
    {
        public int StartPrice { get; set; }
        public int AdultPrice { get; set; }
        public int ExcludeChildFlag { get; set; }
        public int ChildPrice { get; set; }
        public int FreeChildPrice { get; set; }
        public object RoomGrapFlag { get; set; }
        public int FlightTicketType { get; set; }
        public int StrategyType { get; set; }
        public int BookCityCode { get; set; }
        public string DepartureCityCode { get; set; }
        public int Discount { get; set; }
        public object DiscountDesc { get; set; }
        public string PromotionIntro { get; set; }
        public string LowestPriceName { get; set; }
        public int MobileOnlyFlag { get; set; }
        public int SharingPromotionId { get; set; }
        public int SharingPreferential { get; set; }
        public Stockinfo StockInfo { get; set; }
        public string WeekDay { get; set; }
        public int IsRealTimePrice { get; set; }
        public int VendorId { get; set; }
        public object ResId { get; set; }
        public string RealTimeTips { get; set; }
        public object CutPrice { get; set; }
        public object MaxCoupon { get; set; }
        public string PlanDate { get; set; }
        public string PlanWeek { get; set; }
    }

    public class Stockinfo
    {
        public int StockSign { get; set; }
        public int? StockNum { get; set; }
    }

    public class Promotionlist
    {
        public string PromotionName { get; set; }
        public int ThemeId { get; set; }
        public int Type { get; set; }
        public string TagName { get; set; }
        public string TagColor { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityContent { get; set; }
        public int DiscountPrice { get; set; }
        public object[] PlanDates { get; set; }
        public Plandatesforpc PlanDatesForPc { get; set; }
        public int IsToStart { get; set; }
    }

    public class Plandatesforpc
    {
    }

}