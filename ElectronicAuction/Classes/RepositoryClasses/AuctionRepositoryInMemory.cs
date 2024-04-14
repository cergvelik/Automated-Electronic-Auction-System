using ElectronicAuction.Interfaces.AuctionInterfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;

namespace ElectronicAuction.Classes.RepositoryClasses
{
    internal class AuctionRepositoryInMemory:IAuctionRepository //класс репозитория аукционов в памяти (не SQL)
    {
        private readonly Dictionary<int, IAuction> _auctions = new Dictionary<int, IAuction>(); //словарь аукционов

        public IAuction GetAuction(int id) { return null; } //получение любого аукциона по id

        public void AddAuction(IAuction auction) { } //добавление аукциона в словарь

        public void ReturnAuction(int id, IAuction auction) { } //обновление аукциона в словаре

        public IAuctionWithBid GetAuctionWithBid(int id) { return null; } //получение аукциона со ставкой из словаря


    }
}
