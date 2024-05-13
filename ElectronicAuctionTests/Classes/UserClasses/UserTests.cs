using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//using Microsoft.IdentityModel.Tokens;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Classes.UserClasses.Tests
{
    //что нужно проверять? Особо ничего, это простой класс без методов, просто моделька
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void UserTest()
        {
            User user1 = new User("Ivan", "ivan@gmail.com", "1111");
            User user2 = new User("Ian", "ian@gmail.com", "1234");
            string expected = "Ivan";
            string actual = user1.Name;

            Assert.AreSame(expected, actual, "Имена разные {0} {1}",expected,actual);
            Debug.WriteLine(user1.UserId);
            Debug.WriteLine(user2.UserId);
        }
        
    }
}