using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class AuctionRepositoryInSQL:IAuctionRepository
    {
        public AuctionRepositoryInSQL() { } //конструктор класса

        public void AddAuctionWithBid(IAuction auction) { } //добавление аукциона со ставкой в базу данных

        public void ReturnAuctionWithBid(int id, IAuctionWithBid auction) { } //обновление аукциона со ставкой в базе

        public IAuctionWithBid GetAuctionWithBid(int id) { return null; } //получение аукциона со ставкой из базы

        public List<IAuction> GetAllAuctions() { return null; }

        public List<IAuctionWithBid> GetAllAuctionsWithBid() { return null; } //получение списка всех аукционов со ставкой
    }
}
