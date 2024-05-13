using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ElectronicAuction.Classes.SecondaryServices;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Classes.MainServices;
using ElectronicAuction.Classes.Account;

namespace ElectronicAuctionTests.Classes.Account
{
    //что нужно проверять? - Надо задать вопрос, чего мы хотим от этого класса
    //мы хотим чтобы класс выполнил один единственный метод - создал аккаунт, запустив нужные репозитории, сервисы и прочее прочее
    [TestClass()]
    public class AccountCreatorTests
    {
        [TestMethod()]
        public void AccountCreator_DefaultConstructor_AccountCreatorReturned()
        {
            AccountCreator accountCreator = new AccountCreator();

            Assert.IsNotNull(accountCreator);
        }
        [TestMethod()]
        public void CreateConsolePersonalAccount_AccountReturned()
        {
            //если аккаунт корректно создан - значит все остальное тоже было создано
            ConsolePersonalAccount account = AccountCreator.CreateConsolePersonalAccount("");

            Assert.IsNotNull(account);

            //Assert.IsNotNull(auctionRepository);
            //Assert.IsNotNull(auctionCreationService);
            //Assert.IsNotNull(auctionService);
        }
    }
}