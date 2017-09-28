using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerConsole.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrawlerConsole.DAL;
using System.Threading.Tasks;

namespace CrawlerConsole.BLL.Tests
{
    [TestClass()]
    public class CrawlerBusinessComponentTests
    {
        
        [TestMethod()]
        public void DownLineInfoTest()
        {
            using (CrawlerDbContext dbContext = new CrawlerDbContext())
            {
                CrawlerBusinessComponent bc = new CrawlerBusinessComponent(dbContext);
                bc.DownLineInfo("苏州");
                Assert.Fail();
            }
                
        }
    }
}