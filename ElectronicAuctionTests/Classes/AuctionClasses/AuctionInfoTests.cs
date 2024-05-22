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
        public void ToString_InfoReturned() 
        {
            string expected = "sdadafafa";

            AuctionInfo auctionInfo = new AuctionInfo(expected);

            string actual = auctionInfo.ToString();

            //метод должен вернуть string.empty 
            StringAssert.Equals(actual, expected);
        }
    }
}