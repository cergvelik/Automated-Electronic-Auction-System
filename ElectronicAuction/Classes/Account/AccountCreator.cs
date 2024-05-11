using ElectronicAuction.Classes.RepositoryClasses;
using ElectronicAuction.Classes.SecondaryServices;
using ElectronicAuction.Classes.MainServices;

namespace ElectronicAuction.Classes.Account
{
    internal class AccountCreator
    {
        public static ConsolePersonalAccount CreateConsolePersonalAccount(string connection)
        {
            AuctionRepositoryInSQL auctionRepository = new AuctionRepositoryInSQL(connection);
            BidRepositoryInSQL bidRepository = new BidRepositoryInSQL(connection);
            ThingRepositoryInSQL thingRepository = new ThingRepositoryInSQL(connection);
            UserRepositoryInSQL userRepository = new UserRepositoryInSQL(connection);

            AuctionCreationService auctionCreationService = new AuctionCreationService(auctionRepository, bidRepository, thingRepository, userRepository);
            AuctionInfoService auctionInfoService = new AuctionInfoService(auctionRepository);
            BidService bidService = new BidService(bidRepository, auctionRepository, userRepository);
            UserCreateService userCreateService = new UserCreateService(userRepository);
            UserLoginService userLoginService = new UserLoginService(userRepository);

            AuctionService auctionService = new AuctionService(bidService, auctionCreationService, auctionInfoService);
            UserService userService = new UserService(userCreateService, userLoginService);

            ConsolePersonalAccount account = new ConsolePersonalAccount(auctionService, userService);

            return account;
        }
    }
}
