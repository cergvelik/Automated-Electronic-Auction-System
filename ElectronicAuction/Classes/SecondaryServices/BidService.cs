﻿using ElectronicAuction.Interfaces.Services;
using ElectronicAuction.Interfaces.RepositoryInterfaces;
using ElectronicAuction.Classes.AuctionClasses;
using ElectronicAuction.Classes.UserClasses;

namespace ElectronicAuction.Classes.SecondaryServices
{
    public class BidService:IBidService
    {
        private readonly IBidRepository _bidRepository;

        private readonly IAuctionRepository _auctionRepository;

        private readonly IUserRepository _userRepository;

        public BidService(IBidRepository bidRepository, IAuctionRepository auctionRepository, IUserRepository userRepository)//конструктор класса
        {
            _bidRepository = bidRepository;
            _auctionRepository = auctionRepository;
            _userRepository = userRepository;
        }

        public void PlaceBid(int userId, int auctionId, decimal bid) //размещение ставки на аукционе
        {
            var Auction = _auctionRepository.GetAuctionWithBid(auctionId); //достаем аукцион
            var User = _userRepository.GetUser(userId); //достаем пользователя
            Bid NewBid = new Bid(User.UserId, bid);
            Auction.AddBid(NewBid); //добавляем к аукциону ставку
            _bidRepository.AddBid(NewBid); //добавляем в базу данных ставку
            _auctionRepository.ReturnAuctionWithBid(auctionId, Auction); //возвращаем измененный аукцион в базу данных
        }
    }
}
