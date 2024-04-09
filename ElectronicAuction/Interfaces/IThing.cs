using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicAuction.Interfaces
{
    internal interface IThing
    {
        int ThingId { get; }
        string Title { get; }
        string Description { get; }
        int Price { get; }
    }
}
