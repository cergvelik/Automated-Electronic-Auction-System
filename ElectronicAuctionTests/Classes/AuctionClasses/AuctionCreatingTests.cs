using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.AuctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.Account;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.MainServices;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.AuctionClasses.Tests
{
    [TestClass()]
    public class AuctionCreatingTests
    {
        //класс заключающийся в единственном методе
        [TestMethod()]
        public void CreateAuctionWithBidTest()
        {
            //оказывается есть 3 разных CreateAuctionWithBid в разных классах           
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>(); // заполним ка наш лист
            Thing thing = new Thing("plate", "part of platemail", 100);   
            
            things.Add(thing);                                         
            var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона

            Assert.IsNotNull(Auction, "аукцион не может быть создан");
        }
    }
}