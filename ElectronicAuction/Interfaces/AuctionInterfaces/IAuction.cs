using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.AuctionInterfaces
{
    internal interface IAuction
    {
        int AuctionId { get; }
        IThing Thing { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }
}
