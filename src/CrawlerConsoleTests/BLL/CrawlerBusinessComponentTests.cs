using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerConsole.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerConsole.BLL.Tests
{
    [TestClass()]
    public class CrawlerBusinessComponentTests
    {
        CrawlerBusinessComponent bc = new CrawlerBusinessComponent();
        [TestMethod()]
        public void DownLineInfoTest()
        {
            
            bc.DownLineInfo("苏州");
            Assert.Fail();
        }
    }
}