using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Interfaces.ServicesInterfaces
{
    public interface IAuctionInfoService
    {
        AuctionInfo GetInfoAboutAuction(int auctionId);
        List<AuctionInfo> GetInfoAboutAllAuctions();
    }
}
