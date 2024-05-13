using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.AuctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using System.Diagnostics;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.AuctionClasses.Tests
{
    [TestClass()]
    public class AuctionWithBidTests
    {

        [TestMethod()]
        public void AddBid_AmountIsGreater_AddBid()
        {
            //почему то ставка не хочет создаваться за пределами метода, придется все дублировать
            List<IThing> things = new List<IThing>();
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            Bid bid = new Bid(user.UserId, 101);
            Bid bid2 = new Bid(user.UserId, 150);

            AuctionWithBid awb = new AuctionWithBid(things, user, bid);
            awb.AddBid(bid2);

            Debug.WriteLine("вторая ставка:" + awb.Bids[1].Amount);
            Assert.IsTrue(awb.Bids.Count == 2, "Ставка не может быть добавлена");
        }
        [TestMethod()]
        public void AddBid_AmountIsLesser_Return()
        {
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>(); 

            var awb = AuctionCreating.CreateAuctionWithBid(things, user);

            Bid bid2 = new Bid(user.UserId, 0);

            awb.AddBid(bid2);

            Assert.IsTrue(awb.Bids.Count == 1, "Добавленная ставка не больше предыдущей! Так не должно быть!");
        }
        //еще нужно проверить свойство метода auction is closed, но для этого тоже нужен Moq, который все поломает, как нибудь потом
    }
}