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
    public class AuctionRepositoryInSQLTests
    {
        private string _connectionString;
        private AuctionRepositoryInSQL _auctionRepositoryInSql;
        private User _user;

        [TestInitialize]
        public void TestInitialize()
        {
            _connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            _auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            _user = new User("йцу", "йцуйцуй@mail.ru", "****");
        }
        //[TestMethod()]
        //public void AddAuctionWithBid_AuctionInserted_AuctionAddedToDataBase ()
        //{
        //    string connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
        //    AuctionRepositoryInSQL auctionRepositoryInSql = new AuctionRepositoryInSQL(connectionString);

        //    User user = new User("йцу", "йцуйцуй@mail.ru", "****");
        //    List<IThing> things = new List<IThing>(); // заполним ка наш лист
        //    Thing thing = new Thing("plate", "part of platemail", 100);

        //    things.Add(thing);
        //    var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона

        //    var writer = new StringWriter();
        //    Console.SetOut(writer);

        //    auctionRepositoryInSql.AddAuctionWithBid(Auction);
        //    string output = writer.GetStringBuilder().ToString();

        //    StringAssert.Contains(output, "Аукцион успешно создан", "Аукцион не может быть добавлен в базу данных");
        //    Debug.WriteLine(output);
        //}

        //этот метод работает даже если у аукциона нетту вещей, это опасно
        //[TestMethod()]
        //public void AddAuctionWithBid_AuctionWithouttingsInserted_AuctionDenied()
        //{
        //    string connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
        //    AuctionRepositoryInSQL auctionRepositoryInSql = new AuctionRepositoryInSQL(connectionString);

        //    User user = new User("йцу", "йцуйцуй@mail.ru", "****");
        //    List<IThing> things = new List<IThing>(); // заполним ка наш лист
            
        //    var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона

        //    var writer = new StringWriter();
        //    Console.SetOut(writer);

        //    auctionRepositoryInSql.AddAuctionWithBid(Auction);
        //    string output = writer.GetStringBuilder().ToString();

        //    StringAssert.Contains(output, "Аукцион успешно создан", "Аукцион не может быть добавлен в базу данных");
        //    Debug.WriteLine(output);
        //}
        [TestMethod()]
        public void ReturnAuctionWithBid_AuctionWithNewBids_AuctionUpdated()
        {
            User user2 = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>(); // заполним ка наш лист
            Thing thing = new Thing("plate", "part of platemail", 100);

            var Auction = AuctionCreating.CreateAuctionWithBid(things, user2); //создаем объект аукциона
            _auctionRepositoryInSql.ReturnAuctionWithBid(10001, Auction);

            //не до конца понимаю принцип работы этого метода
        }
        [TestMethod()]
        public void GetAuctionWithBid_IdInserted_AuctionWithBidDReturned()
        {
            //пока что null
            //AuctionWithBid auction = _auctionRepositoryInSql.GetAuctionWithBid(10001);
        }
    }
    
}