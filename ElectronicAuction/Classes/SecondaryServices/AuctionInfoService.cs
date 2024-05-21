using ElectronicAuction.Interfaces.ServicesInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class AuctionInfoService:IAuctionInfoService //класс отвечающий за информацию о аукционе 
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionInfoService(IAuctionRepository auctionRepository) { _auctionRepository = auctionRepository; }

        public AuctionInfo GetInfoAboutAuction(int id)
        {
            IAuctionWithBid auction = _auctionRepository.GetAuctionWithBid(id);
            if (auction == null)
            {
                return new AuctionInfo("Аукцион с таким ID не найден.");
            }
            AuctionInfo auctionInfo = new AuctionInfo(ReportGenerator.GenerateReport(auction));
            return auctionInfo;
        } //получение информации об аукционе

        public List<AuctionInfo> GetInfoAboutAllAuctions() {
            List<IAuctionWithBid> auctions = _auctionRepository.GetAllAuctionsWithBid();
            List<AuctionInfo> auctionInfos = new List<AuctionInfo>();

            foreach (var auction in auctions)
            {
                AuctionInfo auctionInfo = new AuctionInfo(ReportGenerator.GenerateReport(auction));
                auctionInfos.Add(auctionInfo);
            }

            return auctionInfos;
        } //получение информации о всех аукционах
    }
}
