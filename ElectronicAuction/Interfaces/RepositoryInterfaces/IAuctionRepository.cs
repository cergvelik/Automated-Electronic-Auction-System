using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IAuctionRepository:IAuctionWithBidRepository
    {
        List<IAuction> GetAllAuctions(); //получение всех аукционов независимо от их вида
    }
}
