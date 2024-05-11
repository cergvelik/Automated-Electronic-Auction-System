using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Interfaces.UserInterfaces;
using System.Xml.Linq;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class AuctionCreationService:IAuctionCreationService
    {
        private readonly IAuctionRepository _auctionRepository;

        private readonly IBidRepository _bidRepository;

        private readonly IThingRepository _thingRepository;

        private readonly IUserRepository _userRepository;

        private readonly AuctionCreating _createAuction;

        public AuctionCreationService(IAuctionRepository auctionRepository, IBidRepository bidRepository, IThingRepository thingRepository)//конструткор класса
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
            _thingRepository = thingRepository;
        }        
        public AuctionCreationService(IAuctionRepository auctionRepository, IBidRepository bidRepository, IThingRepository thingRepository, IUserRepository userRepository)//конструткор класса
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
            _thingRepository = thingRepository;
            _userRepository = userRepository;
        }

        public void CreateAuctionWithBid(int userId, List<IThing> things)
        {
            IUser? _user = _userRepository.GetUser(userId); //достаем пользователя
            var _auction = AuctionCreating.CreateAuctionWithBid(things, _user); //создаем объект аукциона
            _auctionRepository.AddAuctionWithBid(_auction); // добавление аукциона в базу данных
            _bidRepository.AddBid(_auction.Bids[0], _auction.AuctionId); // добавление ставки
            foreach (var thing in things)
            {
                _thingRepository.AddThing(thing, _auction.AuctionId); // добавление каждой вещи в БД
            }
        }
    }
}
