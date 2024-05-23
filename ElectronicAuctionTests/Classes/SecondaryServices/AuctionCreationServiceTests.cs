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

namespace ElectronicAuction.Classes.SecondaryServices.Tests
{
    [TestClass()]
    public class AuctionCreationServiceTests
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
            _user = new User("йцу", "йцуйцуй@mail.ru", "****");
            _auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            _userRepositoryInSql = new UserRepositoryInSQL(_connectionString);
            _bidRepositoryInSql = new BidRepositoryInSQL(_connectionString);
            _thingRepositoryInSql = new ThingRepositoryInSQL(_connectionString);
        }

        [TestMethod()]
        public void AuctionCreationServiceTest()
        {
            AuctionCreationService auctionCreationService1 = new AuctionCreationService(_auctionRepositoryInSql, _bidRepositoryInSql, _thingRepositoryInSql, _userRepositoryInSql);
            AuctionCreationService auctionCreationService2 = new AuctionCreationService(_auctionRepositoryInSql, _bidRepositoryInSql, _thingRepositoryInSql);

            Assert.IsNotNull(auctionCreationService1,"Сервис аукциона с 4 параметрами не может быть создан");
            Assert.IsNotNull(auctionCreationService2, "Сервис аукциона с 3 параметрами не может быть создан");
        }

        [TestMethod()]
        public void CreateAuctionWithBid_UserIdThingListInserted_AuctionCreated()
        {
            List<IThing> things = new List<IThing>();

            AuctionCreationService auctionCreationService1 = new AuctionCreationService(_auctionRepositoryInSql, _bidRepositoryInSql, _thingRepositoryInSql, _userRepositoryInSql);
            AuctionWithBid auction = auctionCreationService1.CreateAuctionWithBid(_user.UserId, things);

            //таких сообщений больше нету
            //StringAssert.Contains(output, "Аукцион успешно создан", "Сервис создания аукциона не может создать аукцион");
            //StringAssert.Contains(output, "Ставка успешно добавлена", "Сервис создания аукциона не может добавитть первую ставку");
            Assert.IsNotNull(auction, "Сервис создания аукциона не может создать аукцион");
        }



    }
}