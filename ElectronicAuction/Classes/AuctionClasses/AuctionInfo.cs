﻿using ElectronicAuction.Interfaces.AuctionInterfaces;


namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionInfo
    {
        string info { get; set; }

        AuctionInfo(IAuctionWithBid auction)
        {

        }
    }
}
