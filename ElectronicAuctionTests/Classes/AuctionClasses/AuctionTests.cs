using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.AuctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Classes.AuctionClasses.Tests
{
    [TestClass()]
    public class AuctionTests
    {
        [TestMethod()]
        public void АuctionTest()
        {
            //Единственное что надо проверять тут,
            //это свойтство AuctionIsClosed
            //но это можно сделать через AuctionWithBid
            //Auction auction = new Auction();
        }
    }
}