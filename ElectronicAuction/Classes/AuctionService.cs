using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Classes.AuctionClasses;

namespace ElectronicAuction.Classes
{
    internal class AuctionService
    {
        private readonly IAuctionRepository _auctionsRepository;//репозиторий всех аукционов
        private readonly IUserRepository _usersRepository;//репозиторий всех пользователей
        private AuctionCreator _createAuction; 

        public AuctionService() //добавить конструктор класса
        {

        }

        public void PlaceBid(int userId, int auctionId, decimal bid) //размещение ставки
        {
            var auction = _auctionsRepository.GetAuctionWithBid(auctionId);
            var user = _usersRepository.GetUser(userId);

            //надо сделать проверку является ли аукцион аукционом со ставкой

            auction.AddBid(user, bid);

            _auctionsRepository.ReturnAuction(auctionId, auction);
        }

        /*если надо будет добавить вид аукциона без ставки нужно будет создать его, добавить интерфейс репозитория аукционов без ставки
         сделать чтобы IAuctionRepository ссылался на новый интерфейс репозитория аукционов без ставки и добавить такую же функцию как и PlaceBid()
         */
        
        public void CreateAuction(int userId, List<IThing> things, int auctionType) //создание аукциона
        { //вообщем эту функцию наверное нужно поменять полностью, чтобы она соответствовала SOLID, но я не знаю как
            var user = _usersRepository.GetUser(userId);
            switch (auctionType)
            {
                case 1:
                    var auction = _createAuction.CreateAuctionWithBid(things, user);
                    _auctionsRepository.AddAuction(auction);
                    break;

            }
        }
    }
}
