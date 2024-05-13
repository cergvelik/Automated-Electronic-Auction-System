using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.UserClasses;
using System.Diagnostics;

namespace ElectronicAuction.Classes.Tests
{
    [TestClass()]
    public class BidTests
    {
        [TestMethod()]
        public void BidTest()
        {
            User user = new User("йцу", "йцуйцуй@mail.ru", "****");

            Bid bid = new Bid(user.UserId, 100);

            Assert.IsNotNull(bid, "Ставка не может быть создана");
            Debug.WriteLine(bid.BidId);
        }
    }
}