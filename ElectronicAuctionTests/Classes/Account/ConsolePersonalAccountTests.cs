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

namespace ElectronicAuction.Classes.Account.Tests
{
    [TestClass()]
    public class ConsolePersonalAccountTests
    {
        ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount("");

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
        //[TestMethod()]
        //public void Account_Register_Test()
        //{
        //    var mockConsole = new Mock<TextReader>();
        //    var writer = new StringWriter();
        //    Console.SetOut(writer);
        //    Console.SetIn(new StringReader(
        //        "och\n" +
        //        "och@yandex.ru\n" +
        //        "1111\n" +
        //        "och@yandex.ru\n" +
        //        "1111"));

        //    account.AccountRegistration();

        //    //string output = writer.GetStringBuilder().ToString();
        //    //Assert.IsTrue(output.Contains("Чтобы вы хотели сделать? 1-Войти в существующий аккаунт, 2-Зарегистрироваться"));
        //    //Assert.IsTrue(output.Contains("--------Аккаунт--------"));
        //}
    }
}