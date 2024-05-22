using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using Moq;
using System.Data.SqlClient;
using System.Data;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using System.Diagnostics;

namespace ElectronicAuction.Classes.RepositoryClasses.Tests
{
    [TestClass()]
    public class BidRepositoryInSQLTests
    {
        //[TestMethod()]
        //public void AddBid_BidInserted_BidAddedToDataBase()
        //{
        //    string connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
        //    BidRepositoryInSQL bidRepositoryInSql = new BidRepositoryInSQL(connectionString);

        //    User user = new User("йцу", "йцуйцуй@mail.ru", "****");
        //    List<IThing> things = new List<IThing>(); // заполним ка наш лист
        //    Thing thing = new Thing("plate", "part of platemail", 100);

        //    things.Add(thing);
        //    var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона
        //    Bid bid = new Bid(user.UserId, 100);
        //    var writer = new StringWriter();//это для проверки
        //    Console.SetOut(writer);

        //    bidRepositoryInSql.AddBid(bid,Auction.AuctionId);
        //    string output = writer.GetStringBuilder().ToString();

        //    StringAssert.Contains(output, "Ставка успешно добавлена.", "Ставка не может быть добавлен в базу данных");
        //    Debug.WriteLine(output);
        //}

        [TestMethod()]
        public void GetBidTest()
        {
            Assert.IsFalse(false);
            //пока что метод возвращает null
        }
    }
}