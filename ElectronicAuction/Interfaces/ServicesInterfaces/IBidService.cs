using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.Services
{
    public interface IBidService
    {
        void PlaceBid(int userId, int auctionId, decimal bid);
    }

}
