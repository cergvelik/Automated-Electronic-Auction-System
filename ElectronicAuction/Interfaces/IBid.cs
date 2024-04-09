using ElectronicAuction.Interfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces
{
    public interface IBid
    {
        int BidId { get; }
        ICommonUser commonUser { get; }
        decimal Amount { get; }
    }
}
