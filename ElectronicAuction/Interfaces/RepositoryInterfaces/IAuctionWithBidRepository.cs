using ElectronicAuction.Interfaces.AuctionInterfaces;


namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IAuctionWithBidRepository
    {
        IAuctionWithBid GetAuctionWithBid(int id);
    }
}
