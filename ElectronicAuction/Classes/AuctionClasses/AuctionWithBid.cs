using System;
using ElectronicAuction;
using ElectronicAuction.Interfaces;
using ElectronicAuction.Interfaces.UserInterfaces;
using ElectronicAuction.Interfaces.AuctionInterfaces;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionWithBid:IAuctionWithBid
    {
        public int AuctionId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<IBid> Bids { get; set; }
        public IThing Thing { get; }

        AuctionWithBid(int auctionId, IThing thing)
        {
            AuctionId = auctionId;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(14);
            Thing = thing;
        }
    }
}
