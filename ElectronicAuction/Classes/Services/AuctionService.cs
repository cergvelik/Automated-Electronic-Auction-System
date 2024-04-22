using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;

namespace ElectronicAuction.Classes.Services
{
    public class AuctionService
    {
        private readonly IBidService _bidService;
        private readonly IAuctionCreationService _auctionCreationService;
        private readonly IAuctionInfoService _auctionInfoService;

        public AuctionService(IBidService bidService, IAuctionCreationService auctionCreationService, IAuctionInfoService auctionInfoService)
        {
            _bidService = bidService;
            _auctionCreationService = auctionCreationService;
            _auctionInfoService =auctionInfoService;
        }

        public void PlaceBid(int userId, int auctionId, decimal bid)
        {
            _bidService.PlaceBid(userId, auctionId, bid);
        }

        public void CreateAuctionWithBid(int userId, List<IThing> things)
        {
            _auctionCreationService.CreateAuctionWithBid(userId, things);
        }

        public void PrintInfoAboutAuction(int auctionId)
        {
            AuctionInfo info =_auctionInfoService.GetInfoAboutAuction(auctionId);
            Console.WriteLine(info);
        }

        public void PrintInfoAboutAllAuctions()
        {
            List<AuctionInfo> info = _auctionInfoService.GetInfoAboutAllAuctions();
            foreach (var auctionInfo in info)
            {
                Console.WriteLine(auctionInfo.ToString());
            }
        }
    }
}
