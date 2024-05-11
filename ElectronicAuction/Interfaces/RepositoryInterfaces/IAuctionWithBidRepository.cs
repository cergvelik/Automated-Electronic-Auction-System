using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IAuctionWithBidRepository
    {
        void AddAuctionWithBid(IAuctionWithBid auction);

        IAuctionWithBid GetAuctionWithBid(int id); //получение аукциона со ставкой по id

        List<IAuctionWithBid> GetAllAuctionsWithBid(); //получение всех аукционов со ставками

        void ReturnAuctionWithBid(int id, IAuctionWithBid auction); /*возвращение аукциона по Id в репозиторий
        если в аукцион добавляется ставка, его нужно сначала достать из репозитория с помощью
        GetAuction() и потом вернуть его с новой ставкой, этим будет заниматься класс AuctioService*/
    }
}
