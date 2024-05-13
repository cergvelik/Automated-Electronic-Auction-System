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
            ReportGenerator report = new();

            var auction = AuctionCreating.CreateAuctionWithBid(things, user);
            string info=report.GenerateReport(auction);

            Debug.WriteLine(info);//string.empty
            Assert.IsNotNull(info, "метод GenerateReport ничего не возвращает");
        }
    }
}