using ElectronicAuction.Interfaces.AuctionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces
{
    public interface ICatalog
    {
        string Name { get; }
        List<IAuction> Auctions { get; }
    }
}
