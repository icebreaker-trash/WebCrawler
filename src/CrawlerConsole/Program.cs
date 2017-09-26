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
            Timer timer = new Timer(new TimerCallback(mainAction), "苏州", 0, rd.Next(100, 1000));
            Timer timer2 = new Timer(new TimerCallback(mainAction), "上海", 0, rd.Next(100, 1000));

        }


    }
}
