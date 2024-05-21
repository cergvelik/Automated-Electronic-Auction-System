using ElectronicAuction.Interfaces.AuctionInterfaces;
using System.Text;

namespace ElectronicAuction.Classes
{
    public class ReportGenerator : IAuctionReport
    {
        static public string GenerateReport(IAuctionWithBid auction)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID аукциона: {auction.AuctionId}");
            sb.AppendLine($"Статус аукциона: {(auction.CheckAuctionStatus() ? "Закрыт" : "Открыт")}");
            foreach (var thing in auction.Things)
            {
                sb.AppendLine($"ID вещи: {thing.ThingId}, название вещи: {thing.Title}");
            }
            foreach (var bid in auction.Bids)
            {
                sb.AppendLine($"Ставка: {bid.Amount}, создатель ставки: {bid.UserId}");
            }
            sb.AppendLine($"Создатель аукциона: {auction.AuctionCreator.Name}");

            return sb.ToString();
        }
    }

}
