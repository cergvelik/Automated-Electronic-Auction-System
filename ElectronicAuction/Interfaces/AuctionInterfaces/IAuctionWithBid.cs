using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicAuction.Classes;
using ElectronicAuction.Interfaces.UserInterfaces;

namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    public interface IAuctionWithBid:IAuction
    {
        List<Bid> Bids { get; }
        decimal PossibleBid { get; }

        void AddBid(IUser user, decimal amount);
    }
}
