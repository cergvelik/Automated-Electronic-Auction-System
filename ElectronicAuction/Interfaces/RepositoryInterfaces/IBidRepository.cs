﻿using ElectronicAuction.Classes;

namespace ElectronicAuction.Interfaces.RepositoryInterfaces
{
    public interface IBidRepository
    {
        IBid GetBid(int BidId);

        void AddBid(IBid bid, int auctionId);
    }
}
