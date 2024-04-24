using ElectronicAuction.Interfaces.AuctionInterfaces;
using System.Text;

namespace ElectronicAuction.Classes.AuctionClasses
{
    public class AuctionInfo
    {
        private string _info { get; set; }

        public AuctionInfo()
        {
            _info = string.Empty;
        }

        public void GenerateReport(IAuctionReport reportGenerator, IAuctionWithBid auction)
        {
            _info = reportGenerator.GenerateReport(auction);
        }

        public override string ToString()
        {
            return _info;
        }
    }

}
