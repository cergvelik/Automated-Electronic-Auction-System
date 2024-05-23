using ElectronicAuction.Classes;
using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Interfaces.Services
{
    public interface IAuctionCreationService
    {
        //Изменено, по умолчанию void
        AuctionWithBid CreateAuctionWithBid(int userId, List<IThing> things);
    }
}
