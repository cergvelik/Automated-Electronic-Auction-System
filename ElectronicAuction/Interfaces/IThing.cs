using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces
{
    public interface IThing
    {
        int ThingId { get; }
        string Title { get; }
        string Description { get; }
        decimal StartPrice { get; }
        int SellerId { get; }
    }
}
