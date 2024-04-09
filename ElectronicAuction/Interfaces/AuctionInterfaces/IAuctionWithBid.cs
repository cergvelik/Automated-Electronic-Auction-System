using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    public interface IAuctionWithBid:IAuction
    {
        List<IBid> Bids { get; }
    }
}
