using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces.Services
{
    public interface IAuctionCreationService
    {
        void CreateAuctionWithBid(int userId, List<IThing> things);
    }
}
