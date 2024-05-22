using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ElectronicAuction.Classes.SecondaryServices;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Classes.MainServices;

using System.IO;
using Moq;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ElectronicAuction.Classes.Account.Tests
{
    [TestClass()]
    public class ConsolePersonalAccountTests
    {
        ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount("Data Source=WIN-4MKOEQCP9DK\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True");

        [TestMethod()]
        public void InitializateAccount_BadInput_Return()
        {
            var mockConsole = new Mock<TextReader>();
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader("qweqwrw"));

            account.InitializateAccount();
            string output = writer.GetStringBuilder().ToString();

            Assert.IsTrue(output.Contains("Ошибка ввода."));
        }

        //блин, че то я фигню делаю, надо попросить антона чтобы он добавил вариант выхода в каждой опции
        [TestMethod()]
        public void AccountRegistration_AccountLogin_Test()
        {
            var mockConsole = new Mock<TextReader>();
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader(
                "och\n" +
                "och@yandex.ru\n" +
                "1111\n" +
                "och@yandex.ru\n" +
                "1111\n" +
                "qwerrqwrqw"
                ));

            account.AccountRegistration();

            string output = writer.GetStringBuilder().ToString();
            Assert.IsTrue(output.Contains("Вход"), "метод AccountRegistration не отвечает");
            Assert.IsTrue(output.Contains("Добро пожаловать, och!"));
            Assert.IsTrue(output.Contains("Меню"));
            Assert.IsTrue(output.Contains("Ошибка ввода."));
        }

        //когда программа не находит пользователя в бд, оно пишет ошибку, но продолжает вызывать цепоччку методов
        //как будто ессли бы нашла пользователя
        //[TestMethod()]
        //public void AccountLogin_DontExistingUserInserted_AccessDenied()
        //{
        //    var mockConsole = new Mock<TextReader>();
        //    var writer = new StringWriter();
        //    Console.SetOut(writer);
        //    Console.SetIn(new StringReader("qwerrqwrqw"));

        //    account.AccountLogin("Skuf@skufuslugi.ru", "skuf");

        //    string output = writer.GetStringBuilder().ToString();
        //    Assert.IsTrue(output.Contains("Ошибка ввода."));
        //}
        [TestMethod()]
        public void AccountLogin_ExistingUserInserted_UserReturnedFromDataBase()
        {
            var mockConsole = new Mock<TextReader>();
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader("qwerrqwrqw"));

            account.AccountLogin("och@yandex.ru", "1111");

            string output = writer.GetStringBuilder().ToString();
            Assert.IsTrue(output.Contains("Ошибка ввода."));
        }
    }
}