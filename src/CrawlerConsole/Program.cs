using System;
using System.Collections;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {

            CrawlerBusinessComponent bc = new CrawlerBusinessComponent();
            Random rd = new Random(System.DateTime.Now.Millisecond);
            Action<object> mainAction = (item) => bc.DownLineInfo(item);
            Timer timer = new Timer(new TimerCallback(mainAction), "重庆", 0, rd.Next(100, 1000));
            Timer timer2 = new Timer(new TimerCallback(mainAction), "郑州", 0, rd.Next(100, 1000));
            Timer timer3 = new Timer(new TimerCallback(mainAction), "镇江", 0, rd.Next(100, 1000));
            Timer timer4 = new Timer(new TimerCallback(mainAction), "漳州", 0, rd.Next(100, 1000));


        }


    }
}
