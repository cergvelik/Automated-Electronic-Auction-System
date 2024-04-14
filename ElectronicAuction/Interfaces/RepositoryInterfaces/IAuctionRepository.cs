using ElectronicAuction.Interfaces.AuctionInterfaces;

namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IAuctionRepository:IAuctionWithBidRepository
    {
        IAuction GetAuction(int id); //получение аукциона по Id

        void ReturnAuction(int id, IAuction auction); /*возвращение аукциона по Id в репозиторий
        если в аукцион добавляется ставка, его нужно сначала достать из репозитория с помощью
        GetAuction() и потом вернуть его с новой ставкой, этим будет заниматься класс AuctioService*/

        void AddAuction(IAuction auction);
    }
}
