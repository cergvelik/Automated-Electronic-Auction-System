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
    public class ThingRepositoryInSQLTests
    {
        [TestMethod()]
        public void AddThing_ThingInserted_ThingAddedToDataBase()
        {
            string connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";
            ThingRepositoryInSQL thingRepositoryInSql = new ThingRepositoryInSQL(connectionString);

            User user = new User("йцу", "йцуйцуй@mail.ru", "****");
            List<IThing> things = new List<IThing>(); // заполним ка наш лист
            Thing thing = new Thing("plate", "part of platemail", 100);

            things.Add(thing);
            var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона
            var writer = new StringWriter();//это для проверки
            Console.SetOut(writer);

            thingRepositoryInSql.AddThing(thing, Auction.AuctionId);
            string output = writer.GetStringBuilder().ToString();

            StringAssert.Contains(output, "Вещь успешно добавлена.", "Вещь не может быть добавлена в базу данных");
            Debug.WriteLine(output);
        }

        [TestMethod()]
        public void GetThingTest()
        {
            //пока что метод возвращает null
        }
    }
}