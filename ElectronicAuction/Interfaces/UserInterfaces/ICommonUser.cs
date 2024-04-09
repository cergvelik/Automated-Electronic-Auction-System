using ElectronicAuction.Interfaces.AuctionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.UserInterfaces
{
    internal interface ICommonUser:IUser
    {
        public void CreateAuction();
        public void PlaceABet(IAuction Auction, IBid Bid);
    }
}
