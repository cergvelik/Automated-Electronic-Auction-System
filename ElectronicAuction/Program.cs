using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Classes.UserClasses;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes;

namespace ElectronicAuction
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CommonUser Krytish = new CommonUser("Абоб","Абобов","cergev@gmail.com","aboba123");
            Console.WriteLine(Krytish.UserId);
        }
    }
}