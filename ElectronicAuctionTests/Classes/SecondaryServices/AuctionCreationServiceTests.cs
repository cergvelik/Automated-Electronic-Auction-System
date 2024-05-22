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
        private AuctionRepositoryInSQL _auctionRepositoryInSql;
        private User _user;

        [TestInitialize]
        public void TestInitialize()
        {
            _connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            _auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            _user = new User("AuctionCreationService", "AuctionCreationService@mail.ru", "AuctionCreationService");
        }

        [TestMethod()]
        public void AuctionCreationServiceTest()
        {
            AuctionRepositoryInSQL auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            UserRepositoryInSQL userRepositoryInSql = new UserRepositoryInSQL(_connectionString);
            ThingRepositoryInSQL thingRepositoryInSql = new ThingRepositoryInSQL(_connectionString);
            BidRepositoryInSQL bidRepositoryInSql = new BidRepositoryInSQL(_connectionString);

            AuctionCreationService auctionCreationService1 = new AuctionCreationService(auctionRepositoryInSql, bidRepositoryInSql, thingRepositoryInSql, userRepositoryInSql);
            AuctionCreationService auctionCreationService2 = new AuctionCreationService(auctionRepositoryInSql, bidRepositoryInSql, thingRepositoryInSql);

            Assert.IsNotNull(auctionCreationService1,"Сервис аукциона с 4 параметрами не может быть создан");
            Assert.IsNotNull(auctionCreationService2, "Сервис аукциона с 3 параметрами не может быть создан");
        }

        [TestMethod()]
        public void CreateAuctionWithBid_UserIdThingListInserted_AuctionCreated()
        {
            AuctionRepositoryInSQL auctionRepositoryInSql = new AuctionRepositoryInSQL(_connectionString);
            UserRepositoryInSQL userRepositoryInSql = new UserRepositoryInSQL(_connectionString);
            ThingRepositoryInSQL thingRepositoryInSql = new ThingRepositoryInSQL(_connectionString);
            BidRepositoryInSQL bidRepositoryInSql = new BidRepositoryInSQL(_connectionString);
            List<IThing> things = new List<IThing>();
            var writer = new StringWriter();//это для проверки
            Console.SetOut(writer);

            AuctionCreationService auctionCreationService1 = new AuctionCreationService(auctionRepositoryInSql, bidRepositoryInSql, thingRepositoryInSql, userRepositoryInSql);
            auctionCreationService1.CreateAuctionWithBid(_user.UserId, things);
            string output = writer.GetStringBuilder().ToString();

            StringAssert.Contains(output, "Аукцион успешно создан", "Сервис создания аукциона не может создать аукцион");
            StringAssert.Contains(output, "Ставка успешно добавлена", "Сервис создания аукциона не может добавитть первую ставку");
            Debug.WriteLine(output);
        }



    }
}