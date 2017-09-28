using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CrawlerConsole.BLL;
using CrawlerConsole.DAL;



namespace CrawlerConsole
{
    class Program
    {
        private const int ThreadCount = 4;
        static void Main(string[] args)
        {

            //Parallel
//            Action<string> mainAction = (item) => bc.DownLineInfo(item);
            using (CrawlerDbContext dbContext = new CrawlerDbContext())
            {
                CrawlerBusinessComponent bc = new CrawlerBusinessComponent(dbContext);
                Random rd = new Random(System.DateTime.Now.Millisecond);
                var strArray = dbContext.T_DepartureCity.Select(city => city.CityName).ToArrayAsync().Result;


                Task task = Task.Run(() => { });
                task.ContinueWith((fg) => { }, TaskContinuationOptions.OnlyOnCanceled);
                Task faultedTask = task.ContinueWith(
                    (acctask) =>
                    {

                    }, TaskContinuationOptions.OnlyOnCanceled);

                //Func<string, Task<string>> MyRecusion = (city) =>
                //{

                //    return new Task<string>(() => { return ""; });
                //};
                //Func<string[], Task> recusionFunc = (citys) =>
                //{
                //    var e = citys.GetEnumerator();
                //    while (e.MoveNext())
                //    {
                //        var tmp = e.Current as string;
                //        MyRecusion(tmp);
                //    }
                //    return new Task(() => { });
                //};


                //int RunningTaskCount = 0;
                //foreach (var departCity in dbContext.T_DepartureCity.Select(city=>city.CityName))
                //{
                //    Task task = Task.Run(async () => {await bc.DownLineInfo(departCity); });

                //    RunningTaskCount++;
                //    if (RunningTaskCount>= ThreadCount)
                //    {

                //    }
                //}

            }

            //Timer timer = new Timer(new TimerCallback(mainAction), "重庆", 0, rd.Next(100, 1000));
            //Timer timer2 = new Timer(new TimerCallback(mainAction), "郑州", 0, rd.Next(100, 1000));
            //Timer timer3 = new Timer(new TimerCallback(mainAction), "镇江", 0, rd.Next(100, 1000));
            //Timer timer4 = new Timer(new TimerCallback(mainAction), "漳州", 0, rd.Next(100, 1000));
            
            Console.ReadKey();


        }


    }
}
