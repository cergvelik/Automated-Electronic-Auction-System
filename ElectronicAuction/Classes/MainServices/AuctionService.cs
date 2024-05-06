using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;

namespace ElectronicAuction.Classes.Services
{
    public class AuctionService
    {
        private readonly IBidService _bidService; //класс отвечающий за выставление ставки
        private readonly IAuctionCreationService _auctionCreationService; //класс отвечающий за создание аукционов
        private readonly IAuctionInfoService _auctionInfoService; //класс отвечающий за получение информации об аукционе

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

        public AuctionInfo InfoAboutAuction(int auctionId)
        {
            AuctionInfo info =_auctionInfoService.GetInfoAboutAuction(auctionId);
            return info;
        }

        public List<AuctionInfo> InfoAboutAllAuctions()
        {
            List<AuctionInfo> info = _auctionInfoService.GetInfoAboutAllAuctions();
            return info;
        }
    }
}
