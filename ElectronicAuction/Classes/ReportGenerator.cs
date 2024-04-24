using ElectronicAuction.Interfaces.AuctionInterfaces;
using System.Text;

namespace ElectronicAuction.Classes
{
    public class ReportGenerator : IAuctionReport
    {
        public string GenerateReport(IAuctionWithBid auction)
        {
            StringBuilder sb = new StringBuilder();
            // Здесь формируем отчет о состоянии аукциона
            // список ставок, список вещей, если аукцион завершен, то какому пользователю досталась вещь и т.д.
            return sb.ToString();
        }
    }

}
