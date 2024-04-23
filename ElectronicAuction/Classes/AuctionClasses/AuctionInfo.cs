using ElectronicAuction.Interfaces.AuctionInterfaces;


namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionInfo
    {
        string info { get; set; }

        public AuctionInfo(IAuctionWithBid auction)
        {

        }
    }
}
