using ElectronicAuction.Classes;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    public interface IAuctionWithBid:IAuction
    {
        List<IBid> Bids { get; }
        decimal PossibleBid { get; }

        void AddBid(IBid amount);
    }
}
