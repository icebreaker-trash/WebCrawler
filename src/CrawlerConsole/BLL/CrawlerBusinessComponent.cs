using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CrawlerConsole.DAL;
using CrawlerConsole.DAL.Entity;

namespace CrawlerConsole.BLL
{
    public class CrawlerBusinessComponent
    {

        #region 定义一些参数

        private const int FirstPage = 1;
        private const int LastPage = 35;
        private string port = string.Empty;
        private string lineTitle = string.Empty;
        private string days = string.Empty;
        private string scenic = string.Empty;
        private string hotels = string.Empty;
        private string supplier = string.Empty;
        private string pmRecommendation = string.Empty;
        private int sum = 0;
        private int travelNumber = 0;
        private int commentNumber = 0;
        private string url = string.Empty;
        private string urlPrice = string.Empty;
        private string Groupdate = string.Empty;
        private int adultPrice = 0;
        private int childPrice = 0;
        private CrawlerDbContext _dbContext ;
        #endregion

        public CrawlerBusinessComponent(CrawlerDbContext dbContext)
        {
             this._dbContext = dbContext;
        }

        public async Task DownLineInfo(object obj)
        {

            #region CodeCore

            var city = obj as string;
            if (city == null) return;

            var list = _dbContext.T_ArriveCity.OrderByDescending(x => x.CityName).ToList();
            if (!list.Any()) return;
            {
                var item = _dbContext.T_DepartureCity.FirstOrDefault(x => x.CityName == city);
                if (item == null) return;
                string cityShorthand = item.Abbreviation;
                string cityCode = item.CityCode;
                foreach (var t1 in list)
                {
                    if (!string.IsNullOrWhiteSpace(city) && !string.IsNullOrWhiteSpace(cityShorthand))
                    {
                        var webclient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
                        //定义以UTF-8格式接收文本信息，规避WebClient接收文本信息时夹带乱码问题
                        #region 循环体
                        for (var j = FirstPage; j <= LastPage; j++)
                        {
                            url =
                             // string.Format("http://www.tuniu.com/package/api/flight?productId=210177243&departDate=2017-09-19&departCityCode=2500&backCityCode=2500&bookCityCode=2500&adultNum=2&childNum=0&freeChildNum=0");
                             $"http://s.tuniu.com/search_complex/pkg-{cityShorthand}-0-{t1.CityName}/{j}/";
                            //string.Format("http://www.tuniu.com//package/api/calendar?productId=210177038&bookCityCode=1615&departCityCode=2500&backCityCode=2500");

                            var html = webclient.DownloadStringTaskAsync(url);
                            //var html = webclient.DownloadString(url);
                            #region 先判断是否是自助游线路

                            Regex reg = new Regex(@"<div class=""crumbs"">(?<key>[\s\S]*?)</div>");
                            var str = string.Empty;
                            
                            var matchs = reg.Matches(await html);
                            foreach (Match match in matchs)
                            {
                                str += match.Groups["key"].Value;
                            }
                            if (!str.Contains("自助游"))//非自助游线路 直接跳出循环
                            {
                                break;
                            }
                            #endregion

                            #region 循环抓取所有线路的详细信息
                            //循环获取网页中的线路编号
                            reg = new Regex(@"productId=""(?<key>[^""]*)""");
                            str = string.Empty;
                            matchs = reg.Matches(await html);
                            foreach (Match match in matchs)
                            {
                                str += match.Groups["key"].Value + ",";
                            }
                            if (string.IsNullOrEmpty(str))//没有获取到线路编号 直接跳出循环
                            {
                                break;
                            }


                            string productId = DeleteDuplicates(str);//当前城市所有的线路id列表

                            string[] arr = productId.Split(',');//转成数组

                            List<string> productIdList = new List<string>(arr);

                            foreach (string t in productIdList)
                            {
                                url = $"http://www.tuniu.com/package/{t}";
                                var response = webclient.DownloadString(url);

                                #region 出发港口
                                reg = new Regex(@"<div class=""resource-city-more-selected"">(?<key>[^<]*)</div>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    port = match.Groups["key"].Value;//出发港口
                                }
                                #endregion

                                #region 线路标题
                                reg = new Regex(@"<title>(?<key>[\s\S]*?)</title>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    lineTitle = match.Groups["key"].Value;//线路标题
                                }
                                #endregion

                                #region 天数
                                int num = lineTitle.LastIndexOf("日", StringComparison.Ordinal);
                                if (num > 1)
                                {
                                    days = lineTitle.Substring(num - 1, 2);
                                }

                                #endregion

                                #region 景点
                                reg = new Regex(@"<li class=""detail-journey-4-nav-sub-item""[^>]*><span>(?<key>[\s\S]*?)</span>");

                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    scenic += match.Groups["key"].Value + ",";//景点
                                }

                                if (string.IsNullOrEmpty(scenic))
                                {
                                    reg = new Regex(@"<li class=""detail-journey-4-nav-group""[^>]*><span>(?<key>[\s\S]*?)</span>");
                                    matchs = reg.Matches(response);
                                    foreach (Match match in matchs)
                                    {
                                        scenic += match.Groups["key"].Value + ",";//景点
                                    }
                                }
                                #endregion

                                #region 住宿标准
                                reg = new Regex(@"<span class=""detail-journey-star"">(?<key>[\s\S]*?)</span>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    hotels = match.Groups["key"].Value;//住宿标准
                                }
                                #endregion

                                #region 供应商
                                reg = new Regex(@"<span class=""reource-vendor"">(?<key>[\s\S]*?)</span>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    supplier = match.Groups["key"].Value;//供应商
                                }
                                #endregion

                                #region 产品经理推荐
                                reg = new Regex(@"<div class=""resource-recommend-content-inner"">(?<key>[\s\S]*?)</div>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    pmRecommendation = match.Groups["key"].Value;//产品经理推荐
                                    pmRecommendation = pmRecommendation.Replace("'", "");
                                }
                                #endregion

                                #region 出游人数
                                reg = new Regex(@"<a class=""resource-people-number"" href=""javascript:;"">(?<key>[\s\S]*?)</a>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    travelNumber = Convert.ToInt32(match.Groups["key"].Value);//出游人数

                                }
                                #endregion

                                #region 点评人数
                                reg = new Regex(@"<a class=""resource-people-number"" href=""#comment"" mm=""点击_头部区_基本信息_查看点评"">(?<key>[\s\S]*?)</a>");
                                matchs = reg.Matches(response);
                                foreach (Match match in matchs)
                                {
                                    commentNumber = Convert.ToInt32(match.Groups["key"].Value);//点评人数

                                }
                                #endregion

                                sum += await AddLineInfo(city, t1.CityName, port, lineTitle, days, scenic, hotels, supplier, pmRecommendation, url, travelNumber, commentNumber, t, cityCode);

                            }
                            #endregion

                            if (productIdList.Count < 3 && j > 1)//说明当前页面已是尾页
                            {
                                break;
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        Console.WriteLine(@"当前数据中无此出发城市！");
                    }
                }
                Console.WriteLine($@"本城市{city}执行成功，共抓取线路{sum}条");
            }

            #endregion


            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<Script Language=JavaScript>alert('线路url：" + url + "！,出错原因：" + ex + "');</Script>");
            //}
        }

        #region 去除重复的线路id
        /// <summary>
        /// 去除重复的线路id
        /// </summary>
        /// <param name="str">线路id字符串</param>
        /// <returns></returns>
        public static string DeleteDuplicates(string str)
        {
            string[] arr = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();
            foreach (string s in arr)
            {
                if (!ht.ContainsKey(s))
                {
                    sb.AppendFormat("{0},", s);
                    ht.Add(s, string.Empty);
                }
            }
            return sb.ToString().TrimEnd(',');
        }

        #endregion



        #region 写入数据
        private async Task<int> AddLineInfo(string departCity, string arriveCity, string port, string lineTitle, string days, string scenic, string hotels, string supplier, string pmRecommendation, string url, int soldqty, int commentNumber, string lineNo, string cityCode)
        {
            Guid lineguid = Guid.NewGuid();
            DateTime date = DateTime.Now;
            _dbContext.T_Line.Add(new Line()
            {
                Id = lineguid,
                SiteName = "途牛",
                TypeName = "自助游",
                Departcity = departCity,
                ArriveCity = arriveCity,
                Port = port,
                Linetitle = lineTitle,
                Days = days,
                Scenic = scenic,
                Hotels = hotels,
                Supplier = supplier,
                Traffic = String.Empty,
                Trafficdetail = String.Empty,
                Soldqty = soldqty,
                Url = url,
                Reco = string.Empty,
                CreateDate = date,
                CommentNumber = commentNumber,
                PmRecommendation = pmRecommendation
            });
            //if (num <= 0) return num;

            #region 抓取价格日历json

            var webclient = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            //定义以UTF-8格式接收文本信息，规避WebClient接收文本信息时夹带乱码问题
            urlPrice = $"http://www.tuniu.com//package/api/calendar?productId={lineNo}&bookCityCode={cityCode}";
            var htmlPrice = webclient.DownloadString(urlPrice);

            
            ParseJson jobInfoList = JsonConvert.DeserializeObject<ParseJson>(htmlPrice);

            if (jobInfoList == null || jobInfoList.Success != true || jobInfoList.Data?.CalendarInfo == null) return -1;


            foreach (var t in jobInfoList.Data.CalendarInfo)
            {
                adultPrice = t.AdultPrice;
                childPrice = t.ChildPrice;
                Groupdate = t.PlanDate;
                if (!string.IsNullOrEmpty(Groupdate))
                {
                    Guid groupPriceGuid = Guid.NewGuid();
                    _dbContext.T_GroupPrice.Add(new GroupPrice()
                    {
                        Id = groupPriceGuid,
                        Lineid = lineguid,
                        GroupDate = Groupdate,
                        AdultPrice = adultPrice,
                        ChildPrice = childPrice

                    });

                    //dbContext.Entry<GroupPrice>(new GroupPrice()
                    //{
                    //    Id = groupPriceGuid,
                    //    Lineid = lineguid,
                    //    GroupDate = Groupdate,
                    //    AdultPrice = adultPrice,
                    //    ChildPrice = childPrice


                    //}).State = EntityState.Added;
                }
            }
            return await _dbContext.SaveChangesAsync();

         

            #endregion


        }
        #endregion

    }
}
