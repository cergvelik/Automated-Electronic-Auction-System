using ElectronicAuction.Interfaces.AuctionInterfaces;
using System.Text;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionInfo
    {
        private string _info { get; set; }

        public AuctionInfo(string info)
        {
            _info = info;
        }

        public override string ToString()
        {
            return _info;
        }
    }

}
