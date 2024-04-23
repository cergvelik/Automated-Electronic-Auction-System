using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces;


namespace ElectronicAuction.Classes.RepositoryClasses
{
    public class BidRepositoryInSQL:IBidRepository
    {
        public BidRepositoryInSQL() { } //конструктор класса

        public IBid GetBid(int id) { return null; } //метод получения ставки по id

        public void AddBid(IBid bid) { } //метод добавления ставки в базу данных
    }
}
