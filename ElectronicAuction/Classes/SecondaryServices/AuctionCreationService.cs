using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Classes.AuctionClasses;

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

        public void CreateAuctionWithBid(int userId, List<IThing> things)
        {
            var User = _userRepository.GetUser(userId); //достаем пользователя
            var Auction = AuctionCreating.CreateAuctionWithBid(things, User); //создаем объект аукциона
            _auctionRepository.AddAuctionWithBid(Auction);
            _bidRepository.AddBid(Auction.Bids[0]);
            foreach (var thing in things)
            {
                _thingRepository.AddThing(thing);
            }
        }
    }
}
