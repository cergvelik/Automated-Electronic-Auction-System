using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.RepositoryInterfaces;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class AuctionInfoService:IAuctionInfoService //класс отвечающий за информацию о аукционе 
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionInfoService(IAuctionRepository auctionRepository) { _auctionRepository = auctionRepository; }

        public AuctionInfo GetInfoAboutAuction(int id) { return null; } //получение информации об аукционе

        public List<AuctionInfo> GetInfoAboutAllAuctions() { return null; } //получение информации о всех аукционах
    }
}
