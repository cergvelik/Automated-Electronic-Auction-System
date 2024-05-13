using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicAuction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Classes.Tests
{
    //что нужно проверять? Особо ничего, это простой класс без методов, просто моделька
    [TestClass()]
    public class ThingTests
    {
        [TestMethod()]
        public void ThingTest()
        {
            Thing thing = new Thing("plate", "part of platemail", 100);
            //thing.ThingId = 1000;
            Assert.IsNotNull(thing, "Вещь не может быть создана");
        }
    }
}