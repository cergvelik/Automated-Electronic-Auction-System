using ElectronicAuction.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    public interface IAuction
    {
        int AuctionId { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        List<IThing> Things { get; }
        IUser AuctionCreator { get; }
    }
}
