using ElectronicAuction.Classes;

namespace ElectronicAuction.Interfaces.Services
{
    public interface IAuctionCreationService
    {
        void CreateAuctionWithBid(int userId, List<IThing> things);
    }
}
