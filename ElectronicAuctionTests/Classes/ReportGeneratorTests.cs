using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using System.Diagnostics;

namespace ElectronicAuction.Classes.Tests
{
    [TestClass()]
    public class ReportGeneratorTests
    {
        [TestMethod()]
        public void GenerateReportTest()
        {
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>();
            Thing thing = new Thing("plate", "part of platemail", 100);
            things.Add(thing);

            var auction = AuctionCreating.CreateAuctionWithBid(things, user);
            string info = ReportGenerator.GenerateReport(auction);

            Debug.WriteLine(info);//string.empty
            Assert.IsNotNull(info, "метод GenerateReport ничего не возвращает");
        }
    }
}