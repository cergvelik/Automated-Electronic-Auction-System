using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.SecondaryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes.RepositoryClasses;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.UserInterfaces;
using Microsoft.VisualBasic;

namespace ElectronicAuction.Classes.SecondaryServices.Tests
{
    [TestClass()]
    public class BidServiceTests
    {
        private string _connectionString;
        private User _user;
        private AuctionRepositoryInSQL _auctionRepositoryInSql;
        private UserRepositoryInSQL _userRepositoryInSql;
        private BidRepositoryInSQL _bidRepositoryInSql;
        private ThingRepositoryInSQL _thingRepositoryInSql;
        [TestInitialize]
        public void TestInitialize()
        {
            _connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            _user = new User("BidServiceTests", "BidServiceTests@mail.ru", "BidServiceTests");
            _auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            _userRepositoryInSql = new UserRepositoryInSQL(_connectionString);
            _bidRepositoryInSql = new BidRepositoryInSQL(_connectionString);
            _thingRepositoryInSql = new ThingRepositoryInSQL(_connectionString);
        }
        [TestMethod()]
        public void PlaceBid_UserIdAuctionIdBidInserted_BidAddedToAuction()
        {
            //метод взаимодействует с аукционом, который и в консоли, и в БД
            //нужен AuctionCreationService
            List<IThing> things = new List<IThing>();
            int expected = 100;

            AuctionCreationService auctionCreationService1 = new AuctionCreationService(_auctionRepositoryInSql, _bidRepositoryInSql, _thingRepositoryInSql, _userRepositoryInSql);
            AuctionWithBid auction = auctionCreationService1.CreateAuctionWithBid(_user.UserId, things);
            BidService bidService = new BidService(_bidRepositoryInSql, _auctionRepositoryInSql, _userRepositoryInSql);
            bidService.PlaceBid(_user.UserId, auction.AuctionId, expected);
            decimal actual = auction.Bids[0].Amount;

            Assert.AreEqual(expected, actual);
        }
    }
}