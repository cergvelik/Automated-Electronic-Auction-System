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
    public class UserRepositoryInSQLTests
    {
        string connectionString = "Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True";

        //тот же самый пользователь
        //[TestMethod()]
        //public void AddSameUserAgain_UnigueKeyException()
        //{
        //    UserRepositoryInSQL userRepositoryInSql = new UserRepositoryInSQL(connectionString);

        //    User user = new User("йцу", "йцуйцуй@mail.ru", "****");
        //    List<IThing> things = new List<IThing>(); // заполним ка наш лист
        //    Thing thing = new Thing("plate", "part of platemail", 100);

        //    things.Add(thing);
        //    var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона
        //    var writer = new StringWriter();//это для проверки
        //    Console.SetOut(writer);

        //    userRepositoryInSql.AddUser(user);
        //    string output = writer.GetStringBuilder().ToString();


        //    Debug.WriteLine(output);
        //}

        //чтооож, один раз этот метод сработав, дальше выдает ошибку, т.к. таблица в дб содержит только уникальные значения
        //либо надо делать рандомизатор, либо добавить метод удаления из бд
        //[TestMethod()]
        //public void AddUser_UserInserted_UserAddedToDataBase()
        //{
        //    UserRepositoryInSQL userRepositoryInSql = new UserRepositoryInSQL(connectionString);

        //    User user = new User("йцу1", "йцуйцуй1@mail.ru", "1111");
        //    List<IThing> things = new List<IThing>(); // заполним ка наш лист
        //    Thing thing = new Thing("plate", "part of platemail", 100);

        //    things.Add(thing);
        //    var Auction = AuctionCreating.CreateAuctionWithBid(things, user); //создаем объект аукциона
        //    var writer = new StringWriter();//это для проверки
        //    Console.SetOut(writer);

        //    userRepositoryInSql.AddUser(user);
        //    string output = writer.GetStringBuilder().ToString();

        //    StringAssert.Contains(output, "успешно зарегестрирован", "Пользователь не может быть добавлен в базу данных");
        //    Debug.WriteLine(output);
        //}

        [TestMethod()]
        public void GetUser_UserIdIserted_UserReturned()
        {
            UserRepositoryInSQL userRepositoryInSql = new UserRepositoryInSQL(connectionString);

            User user = (User)userRepositoryInSql.GetUser(1001);

            Assert.IsNotNull(user, "Пользоваель не получен из базы данных");
        }
    }
}