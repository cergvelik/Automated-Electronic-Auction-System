namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    public interface IAuctionReport
    {
        string GenerateReport(IAuctionWithBid auction);
    }
}
