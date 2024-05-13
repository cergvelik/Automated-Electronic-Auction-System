using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.AuctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using System.Diagnostics;

namespace ElectronicAuction.Classes.AuctionClasses.Tests
{
    [TestClass()]
    public class AuctionInfoTests
    {
        [TestMethod()]
        public void GenerateReport_ReportGeneratorAndAuctionWithBid_InfoChanged()
        {
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>();
            var auction = AuctionCreating.CreateAuctionWithBid(things, user);

            AuctionInfo auctionInfo = new AuctionInfo();
            ReportGenerator report = new();


            auctionInfo.GenerateReport(report, auction);
            string info = auctionInfo.ToString();

            //может дополнится
            Assert.IsNotNull(info);
            Debug.WriteLine(info);
        }
        [TestMethod()]
        public void ToString_InfoReturned() 
        {
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>();
            var auction = AuctionCreating.CreateAuctionWithBid(things, user);
            AuctionInfo auctionInfo = new AuctionInfo();

            string info = auctionInfo.ToString();

            //метод должен вернуть string.empty 
            Assert.IsNotNull(info);
            Debug.WriteLine(info.Length+"_"+info);//0
        }
    }
}